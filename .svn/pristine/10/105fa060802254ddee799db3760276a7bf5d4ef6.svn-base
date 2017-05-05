namespace TestManagerService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.TestManagerProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.TestManagerInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // TestManagerProcessInstaller
            // 
            this.TestManagerProcessInstaller.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.TestManagerInstaller});
            this.TestManagerProcessInstaller.Password = null;
            this.TestManagerProcessInstaller.Username = null;
            // 
            // TestManagerInstaller
            // 
            this.TestManagerInstaller.ServiceName = "VpnTestManager";
            this.TestManagerInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.TestManagerProcessInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller TestManagerProcessInstaller;
        private System.ServiceProcess.ServiceInstaller TestManagerInstaller;
    }
}