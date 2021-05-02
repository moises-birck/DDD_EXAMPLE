using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities.Notifications
{
    public class Notifies
    {
        public Notifies()
        {
            Notifications = new List<Notifies>();
        }

        [NotMapped]
        public string PropertyName { get; set; }

        [NotMapped]
        public string Message { get; set; }

        [NotMapped]
        public List<Notifies> Notifications;

        public bool ValidateStringProperty(string value, string propertyName)
        {

            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(propertyName))
            {
                Notifications.Add(new Notifies
                {
                    Message = "Campo Obrigatório",
                    PropertyName = propertyName
                });

                return false;
            }

            return true;
        }

        public bool ValidateDDD(int value, string propertyName)
        {

            if (value < 9 || value > 100 || value.ToString().Length < 2 || string.IsNullOrWhiteSpace(propertyName))
            {
                Notifications.Add(new Notifies
                {
                    Message = "DDD deve conter dois digitos no mínimo e ser maior que 9 e menor que 100",
                    PropertyName = propertyName
                });

                return false;
            }

            return true;

        }

        public bool ValidateDecimal(decimal value, string propertyName)
        {

            if (value < 1 || string.IsNullOrWhiteSpace(propertyName))
            {
                Notifications.Add(new Notifies
                {
                    Message = "Preço por minuto tem que ser maior que 0",
                    PropertyName = propertyName
                });

                return false;
            }

            return true;

        }

        public bool ValidateInt(int value, string propertyName)
        {

            if (value < 1 || string.IsNullOrWhiteSpace(propertyName))
            {
                Notifications.Add(new Notifies
                {
                    Message = "Valor inteiro tem que ser maior que 0",
                    PropertyName = propertyName
                });

                return false;
            }

            return true;

        }
    }
}
