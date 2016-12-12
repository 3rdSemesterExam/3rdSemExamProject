namespace dsr_betalling.Interface
{
    public interface IWebUri
    {
        /// <summary>
        ///     Uri for Webservice
        /// </summary>
        string ResourceUri { get; }

        /// <summary>
        ///     Reading friendly name
        /// </summary>
        string VerboseName { get; }
    }
}