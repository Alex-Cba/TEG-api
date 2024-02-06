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

        public enum ErrorCreateUser
        {
            NONE, ALREADY_EXISTS, EMAIL_EMPTY, PHONE_EMPTY, NAME_EMPTY, PASSWORD_EMPTY
        }

        public enum ErrorUpdateUser
        {
            NONE, USER_NOT_EXISTS, EMAIL_EMPTY, PHONE_EMPTY, NAME_EMPTY,
            ACTIVE_EMPTY, USER_TYPE_EMPTY
        }

        public enum ErrorDeleteEntities
        {
            NOT_FOUND
        }
    }
}
