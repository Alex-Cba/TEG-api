@echo off

REM Example: .\CommandScript.bat ".\CQRS\Commands\Create\User" "Good Example" 
REM - The first part of the script needs to have the exact location of the script specified in order to be executed

REM Inputs
if "%~1"=="" (
    echo Please, input route and class name
    exit /b 1
)

if "%2"=="" (
    echo Please, input class name
    exit /b 1
)

REM Path
set "targetPath=%~1"
set "className=%2"

REM Agregar comillas dobles a las rutas y nombres de clase si contienen espacios
set "targetPath=%targetPath:"=%"
set "className=%className:"=%"

REM Check Path
if not exist "%targetPath%" (
    echo The specified path does not exist.
    exit /b 1
)

REM Convert Path to Namespace
set "namespacePath=%targetPath:\=.%"

REM Create "Class"Command.cs
(
    echo using MediatR;
    echo.namespace TEG_api%namespacePath% 
    echo.
    echo {
    echo.    public record %className%Command(/*Request*/^) : IRequest^</*Response*/^> ;
    echo.}
) > "%targetPath%\%className%Command.cs"

REM Create "Class"Handler.cs
(
    echo using MediatR;
    echo using TEG_api.Data;
    echo using TEG_api.Services.Interface;
    echo using AutoMapper;
    echo.
    echo.namespace TEG_api%namespacePath%
    echo {
    echo    public class %className%Handler : IRequestHandler^<%className%Command, /*Response*/^>
    echo. {
    echo        private readonly TEGContext _db;
    echo        private readonly ICRUDService _crudService;
    echo        private readonly IValidator^<CreateUserCommand^> _validator;
    echo        private readonly IMapper _mapper;
    echo.
    echo.       public %className%Handler(TEGContext db^, ICRUDService crudService^, IValidator^<CreateUserCommand^> validator, IMapper mapper^)
    echo.       {
    echo            _db = db;
    echo            _crudService = crudService;
    echo            _validator = validator;
    echo            _mapper = mapper;
    echo.       }
    echo.
    echo    }
    echo.}
) > "%targetPath%\%className%Handler.cs"

REM Create "Class"Validator.cs
(
    echo using FluentValidation;
    echo using TEG_api.Data;
    echo.namespace TEG_api%namespacePath%
    echo.
    echo {
    echo    public class %className%Validator : AbstractValidator^<%className%Command^>
    echo.   {
    echo        private readonly TEGContext _db;
    echo.
    echo        public %className%Validator(TEGContext db^)
    echo.       {
    echo.            RuleFor(x =^> x.Example^).NotEmpty(^).WithMessage("Example can't be empty"^);
    echo            _db = db;
    echo        }
    echo    }
    echo.}
) > "%targetPath%\%className%Validator.cs"

echo Files generated successfully for the class %className% in the path %targetPath%.
