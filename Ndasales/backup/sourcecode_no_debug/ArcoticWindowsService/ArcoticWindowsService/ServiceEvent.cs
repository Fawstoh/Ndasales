using System;
using System.ServiceProcess;
using System.Threading;


namespace ArcoticWindowsService
{
    public partial class ServiceEvent : ServiceBase
    {
        private Timer oTimer;
        private ServiceTask oServiceTask;
        public ServiceEvent()
        {
            InitializeComponent();
            oServiceTask = new ServiceTask();

            //Service Informations
            this.ServiceName = "Arcotic Windows Service";
        }

        protected override void OnStart(string[] args)
        {
            //Após 15 segundos da inicialização do serviço, executa o processo de envio dos dados de 1 em 1 minuto. Isso pode ser modificado conforme necessidade.
            oTimer = new Timer(new TimerCallback(ProcessStarter), null, 15000, 60000);
            ServiceLog.SaveServiceEvent("Serviço iniciado em " + DateTime.Now);
        }

        protected override void OnStop()
        {
            ServiceLog.SaveServiceEvent("Serviço parado em " + DateTime.Now);
        }

        private void ProcessStarter(object sender)
        {
            oServiceTask.RunInventario();
            oServiceTask.RunVendas();
        }

    }
}
