namespace Hurricane.Shared.Logging
{
    /* List of common possible output desinations for loggers
     * If what you're using isn't on this list, request it on our GitHub page
     * https://github.com/Evairfairy/Hurricane
     * 
     * Something to note though - the goal here is to list destinations only 
     * 
     * For example, "TraceLogger" would be incorrect - you'd call the same 
     * FileLogger logger but in the library implementation, you'd point 
     * logger.WriteTrace() to a different file. */
    public enum LoggerTypeEnum
    {
        FileLogger,
        UILogger,
        CLILogger,
        GUILogger,
        DatabaseLogger,
        NetworkLogger,
        
        /* Just in case */
        MiscLogger,
        MiscLogger1,
        MiscLogger2,
        MiscLogger3,
        MiscLogger4
    }
}