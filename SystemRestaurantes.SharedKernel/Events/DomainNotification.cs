using SystemRestaurantes.SharedKernel.Events.Contracts;

namespace SystemRestaurantes.SharedKernel.Events
{
    public class DomainNotification : IDomainEvent
    {
        //public string Key { get; private set; }
        public string Value { get; private set; }
        //public DateTime DataOcorrida { get; private set; }

        public DomainNotification(string key, string value)
        {
            //this.Key = key;
            this.Value = value;
            //this.DataOcorrida = DateTime.Now;
        }
    }
}
