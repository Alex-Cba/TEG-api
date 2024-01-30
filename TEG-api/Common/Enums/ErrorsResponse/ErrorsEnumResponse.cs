namespace TEG_api.Common.Enums.ErrorsResponse
{
    public class ErrorsEnumResponse
    {
        public enum GenericErros
        {
            GENERIC_ALREADY_EXISTS, GENERIC_NOT_FOUND
        }

        public enum ErrorCreateUser
        {
            NONE, ALREADY_EXISTS, EMAIL_EMPTY, PHONE_EMPTY, NAME_EMPTY, PASSWORD_EMPTY
        }
    }
}
