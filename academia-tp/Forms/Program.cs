namespace Forms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
           Application.Run(new FormGetEspecialidad());
           Application.Run(new FormPostEspecialidad());
           Application.Run(new FormPutEspecialidad());
           Application.Run(new FormDeleteEspecialidad());
           Application.Run(new FormGetPlan());
           Application.Run(new FormPostPlan());
           Application.Run(new FormDeletePlan());
           Application.Run(new FormPutPlan());
        }
    }
}