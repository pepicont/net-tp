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
            Application.Run(new Form3());
            Application.Run(new FormPost());
            Application.Run(new Form2());
            Application.Run(new FormDeleteEspecialidad());
            Application.Run(new FormGetPlan());
            Application.Run(new Form3());
            Application.Run(new FormDeletePlan());
            Application.Run(new Form3());
        }
    }
}