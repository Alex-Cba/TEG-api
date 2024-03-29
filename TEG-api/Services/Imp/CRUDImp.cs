﻿using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using TEG_api.Common.Enums.ErrorsResponse;
using TEG_api.Data;
using TEG_api.Middleware.Exceptions;
using TEG_api.Services.Interface;

namespace TEG_api.Services.Imp
{
    public class CRUDImp : ICRUDService
    {
        private readonly TEGContext _db;
        private readonly ILogger<CRUDImp> _logger;
        private readonly IValidatorFactory _validatorFactory;

        public CRUDImp(TEGContext db, ILogger<CRUDImp> logger, IValidatorFactory validatorFactory)
        {
            _db = db;
            _logger = logger;
            _validatorFactory = validatorFactory;
        }

        public async Task<bool> CheckNotExists<T>(string id) where T : class
        {
            Guid GuidId;
            int IntId;
            T checkNoExists;

            if (Guid.TryParse(id, out GuidId))
            {
                checkNoExists = await _db.Set<T>().FindAsync(GuidId);
            }
            else if (int.TryParse(id, out IntId))
            {
                checkNoExists = await _db.Set<T>().FindAsync(IntId);
            }
            else
            {
                _logger.LogWarning($"The method does support IdType {id}");
                throw new ArgumentException(ErrorsEnumResponse.GenericErros.GENERIC_NOT_SUPPORTED.ToString());
            }

            if (checkNoExists != null)
            {
                _logger.LogWarning("Already exists");
                throw new ExceptionBadRequestClient(ErrorsEnumResponse.GenericErros.GENERIC_ALREADY_EXISTS.ToString());
            }
            return false;
        }

        public async Task<bool> CheckExists<T>(string id) where T : class
        {
            Guid GuidId;
            int IntId;
            T checkExists;

            if (Guid.TryParse(id, out GuidId))
            {
                checkExists = await _db.Set<T>().FindAsync(GuidId);
            }
            else if(int.TryParse(id, out IntId))
            {
                checkExists = await _db.Set<T>().FindAsync(IntId);
            }
            else
            {
                _logger.LogWarning($"The method does support IdType {id}");
                throw new ArgumentException(ErrorsEnumResponse.GenericErros.GENERIC_NOT_SUPPORTED.ToString());
            }

            if (checkExists == null)
            {
                _logger.LogWarning("Not exists");
                throw new ExceptionBadRequestClient(ErrorsEnumResponse.GenericErros.GENERIC_NOT_EXISTS.ToString());
            }
            return true;
        }

        public async Task CheckValidator<T>(T requestCommand) where T : class
        {
            var validator = _validatorFactory.GetValidator<T>();

            if (validator == null)
            {

                _logger.LogWarning($"Validator Not Found, {typeof(T).Name}");
                throw new Exception(ErrorsEnumResponse.GenericErros.GENERIC_NOT_FOUND.ToString());
            }

            var validationResult = await validator.ValidateAsync(requestCommand);

            if (!validationResult.IsValid)
            {
                throw new ExceptionBadRequestClient(validationResult.ToString());
            }
        }

        public async Task<bool> DeleteAsync<T>(string id) where T : class
        {
            Guid GuidId;
            int IntId;
            T entity;
            
            if (Guid.TryParse(id, out GuidId))
            {
                entity = await _db.Set<T>().FindAsync(GuidId);
            }
            else if (int.TryParse(id, out IntId))
            {
                entity = await _db.Set<T>().FindAsync(IntId);
            }
            else
            {
                _logger.LogWarning($"The method does support IdType {id}");
                throw new ArgumentException(ErrorsEnumResponse.GenericErros.GENERIC_NOT_SUPPORTED.ToString());
            }

            if (entity == null)
            {
                _logger.LogWarning($"Not found entity to delete, with {id}");
                throw new KeyNotFoundException(ErrorsEnumResponse.GenericErros.GENERIC_NOT_FOUND.ToString());
                
            }

            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<List<T>> GetAsync<T>() where T : class
        {
            var entity = await _db.Set<T>().ToListAsync();

            if (entity == null)
            {
                _logger.LogWarning("Not found registers of entity");
                throw new KeyNotFoundException(ErrorsEnumResponse.GenericErros.GENERIC_NOT_FOUND.ToString());
                
            }

            return entity;
        }

        public async Task<T> GetByIdAsync<T>(string id) where T : class
        {
            Guid GuidId;
            int IntId;
            T entity;

            if (Guid.TryParse(id, out GuidId))
            {
                entity = await _db.Set<T>().FindAsync(GuidId);
            }
            else if (int.TryParse(id, out IntId))
            {
                entity = await _db.Set<T>().FindAsync(IntId);
            }
            else
            {
                _logger.LogWarning($"The method does support IdType {id}");
                throw new ArgumentException(ErrorsEnumResponse.GenericErros.GENERIC_NOT_SUPPORTED.ToString());
            }

            if (entity == null)
            {
                _logger.LogWarning($"Not found entity with ID {id}");
                throw new KeyNotFoundException(ErrorsEnumResponse.GenericErros.GENERIC_NOT_FOUND.ToString());
            }

            return entity;
        }

        //Testing!!!
        public async Task<bool> PatchAsync<T>(Expression<Func<T, bool>> predicate, string fieldName, object newValue) where T : class
        {
            var entity = await _db.Set<T>().FirstOrDefaultAsync(predicate);

            if (entity == null)
            {
                _logger.LogWarning($"No entity was found that meets the specified predicate");
                throw new ArgumentException(ErrorsEnumResponse.GenericErros.GENERIC_NOT_FOUND.ToString());
            }

            var propertyInfo = typeof(T).GetProperty(fieldName);

            if (propertyInfo == null)
            {
                _logger.LogWarning($"Not found entity with name {fieldName} in entity {typeof(T).Name}");
                throw new ArgumentException(ErrorsEnumResponse.GenericErros.GENERIC_NOT_FOUND.ToString());
            }

            propertyInfo.SetValue(entity, Convert.ChangeType(newValue, propertyInfo.PropertyType));

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<T> PostAsyncNotDuplicate<T>(T entity) where T : class
        {
            PropertyInfo idProperty = typeof(T).GetProperty("Id");

            if (idProperty == null)
            {
                _logger.LogWarning($"Entity does not have an 'Id' property");
                throw new ArgumentException(ErrorsEnumResponse.GenericErros.GENERIC_NOT_FOUND.ToString());
            }

            var entityId = idProperty.GetValue(entity).ToString();

            await CheckNotExists<T>(entityId);

            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task<T> PostAsyncDuplicate<T>(T entity) where T : class
        {
            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        //Testing!!!
        public async Task<T> PutAsync<T>(T entity) where T : class
        {
            var entityType = typeof(T);
            var idProperty = entityType.GetProperty("Id");
            var idValue = idProperty.GetValue(entity);

            var entityToUpdate = await _db.Set<T>().FindAsync(idValue);

            if (entityToUpdate == null)
            {
                _logger.LogWarning($"Entity not found with the provided key values.");
                throw new KeyNotFoundException(ErrorsEnumResponse.GenericErros.GENERIC_NOT_FOUND.ToString());
            }

            _db.Entry(entityToUpdate).CurrentValues.SetValues(entity);
            await _db.SaveChangesAsync();
            return entityToUpdate;
        }

        public async Task<bool> SoftDeleteAsync<T>(T entity) where T : class
        {
            Guid GuidId;
            int IntId;
            T existingEntity;

            var idProperty = typeof(T).GetProperty("Id");
            var idValue = idProperty.GetValue(entity).ToString();

            if (idProperty == null)
            {
                _logger.LogWarning($"Entity does not have an 'Id' property");
                throw new ArgumentException(ErrorsEnumResponse.GenericErros.GENERIC_NOT_FOUND.ToString());
            }

            if(Guid.TryParse(idValue, out GuidId))
            {
                existingEntity = await _db.Set<T>().FindAsync(GuidId);
            }
            else if (int.TryParse(idValue, out IntId))
            {
                existingEntity = await _db.Set<T>().FindAsync(IntId);
            }
            else
            {
                _logger.LogWarning($"The method does support IdType {idValue}");
                throw new ArgumentException(ErrorsEnumResponse.GenericErros.GENERIC_NOT_SUPPORTED.ToString());
            }

            if (existingEntity == null)
            {
                _logger.LogWarning($"No entity found with ID {idProperty}");
                throw new ArgumentException(ErrorsEnumResponse.GenericErros.GENERIC_NOT_FOUND.ToString());
            }

            var propertyInfo = existingEntity.GetType().GetProperty("IsActive");

            if (propertyInfo != null && propertyInfo.PropertyType == typeof(bool))
            {
                var value = (bool)propertyInfo.GetValue(existingEntity);
                propertyInfo.SetValue(existingEntity, !value);

                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                _logger.LogWarning($"The entity cannot be deactivated or activated");
                throw new ArgumentException(ErrorsEnumResponse.GenericErros.GENERIC_NOT_FOUND.ToString());
            }
        }
    }
}
