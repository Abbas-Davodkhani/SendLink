namespace SendingSMS.Common
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base()
        {

        }
        public NotFoundException(string message) : base(message)
        {

        }
        public NotFoundException(string entity, object key)
            : base($"Entity {nameof(entity)} by Id {key} not found")
        {

        }
    }
}
