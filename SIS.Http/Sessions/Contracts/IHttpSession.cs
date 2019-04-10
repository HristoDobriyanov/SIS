namespace SIS.Http.Sessions
{
    public interface IHttpSession
    {
        string Id { get; }

        object GetParameter(string key);

        bool ContainsParameter(string key);

        void AddParameter(string name, object parameter);

        void ClearParameters();
    }
}
