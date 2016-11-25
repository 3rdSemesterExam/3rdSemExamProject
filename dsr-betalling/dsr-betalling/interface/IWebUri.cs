namespace dsr_betalling.@interface
{
    public interface IWebUri
    {
        /// <summary>
        /// Uri for Webservice
        /// </summary>
        string ResourceUri { get; }

        /// <summary>
        /// Reading friendly name
        /// </summary>
        string VerboseName { get; }
    }
}
