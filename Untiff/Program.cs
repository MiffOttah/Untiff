namespace Untiff;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        if (args.Length > 0 && File.Exists(args[0]))
        {
            try
            {
                if (Path.GetExtension(args[0]).Equals(".jpg", StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new Exception("Source and destination filenames are the same.");
                }

                string outFile = Path.ChangeExtension(args[0], ".jpg");
                if (File.Exists(outFile) && MessageBox.Show("There is already a jpeg version of this file. Overwrite it?", "Untiff", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                {
                    return;
                }

                using var img = Image.FromFile(args[0]);
                img.Save(outFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Untiff", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        else
        {
            MessageBox.Show("Please provide a file on the command line.", "Untiff", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}