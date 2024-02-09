namespace TEG_api.Common.Enums.ErrorsResponse
{
    public class ErrorsEnumResponse
    {
        public enum UnHandleExceptionErrors
        {
            UNHANDLE_EXCEPTION
        }
        public enum GenericErros
        {
            GENERIC_ALREADY_EXISTS, GENERIC_NOT_FOUND,
            GENERIC_NOT_EXISTS,
            GENERIC_NOT_SUPPORTED
        }
        public enum ErrorDeleteEntities
        {
            NOT_FOUND
        }

        #region User Errors
        public enum ErrorCreateUser
        {
            NONE, ALREADY_EXISTS, EMAIL_EMPTY, PHONE_EMPTY, NAME_EMPTY, PASSWORD_EMPTY
        }

        public enum ErrorUpdateUser
        {
            NONE, USER_NOT_EXISTS, EMAIL_EMPTY, PHONE_EMPTY, NAME_EMPTY,
            ACTIVE_EMPTY, USER_TYPE_EMPTY
        }
        #endregion

        #region Map
        public enum ErrorCreateMap
        {
            NONE, ALREADY_EXISTS, DESCRIPTION_EMPTY, ACTIVE_EMPTY
        }

        public enum ErrorUpdateMap
        {
            NONE, MAP_NOT_EXISTS, DESCRIPTION_EMPTY, ACTIVE_EMPTY, ID_EMPTY
        }
        #endregion

        #region Continent
        public enum ErrorCreateContinent
        {
            NONE, ALREADY_EXISTS, NAME_EMPTY, VALUE_TROOPS_EMPTY, MAP_ID_EMPTY
        }

        public enum ErrorUpdateContinent
        {
            NONE, CONTINENT_NOT_EXISTS, NAME_EMPTY, VALUE_TROOPS_EMPTY, MAP_ID_EMPTY, ID_EMPTY
        }
        #endregion

        #region Country
        public enum ErrorCreateCountry
        {
            NONE, ALREADY_EXISTS, NAME_EMPTY, TROOPS_EMPTY, CONTINENT_ID_EMPTY
        }

        public enum ErrorUpdateCountry
        {
            NONE, COUNTRY_NOT_EXISTS, NAME_EMPTY, TROOPS_EMPTY, CONTINENT_ID_EMPTY, ID_EMPTY
        }
        #endregion
    }
}
