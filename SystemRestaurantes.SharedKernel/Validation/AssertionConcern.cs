using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SystemRestaurantes.SharedKernel.Events;

namespace SystemRestaurantes.SharedKernel.Validation
{
    public static class AssertionConcern
    {
        public static bool IsSatisfiedBy(params DomainNotification[] validations) // saaber se o contexto e valido ou não
        {
            var notificationsNotNull = validations.Where(validation => validation != null);
            NotifyAll(notificationsNotNull);

            return notificationsNotNull.Count().Equals(0);
        }

        private static void NotifyAll(IEnumerable<DomainNotification> notifications)
        {
            notifications.ToList().ForEach(validation =>
            {
                DomainEvent.Raise<DomainNotification>(validation);
            });
        }

        public static DomainNotification AssertLength(string stringValue, int minimum, int maximum, string message)
        {
            int length = stringValue.Trim().Length;

            return (length < minimum || length > maximum) ?
                new DomainNotification("AssertArgumentLength", message) : null;
        }

        public static DomainNotification AssertMatches(string pattern, string stringValue, string message)
        {
            Regex regex = new Regex(pattern);

            return (!regex.IsMatch(stringValue)) ?
                new DomainNotification("AssertArgumentLength", message) : null;
        }

        public static DomainNotification AssertNotEmpty(string stringValue, string message)
        {
            return (string.IsNullOrEmpty(stringValue)) ?
                new DomainNotification("AssertArgumentNotEmpty", message) : null;
        }

        public static DomainNotification AssertNotNull(object object1, string message)
        {

            return (object1 == null) ?
                new DomainNotification("AssertArgumentNotNull", message) : null;
        }

        public static DomainNotification AssertTrue(bool boolValue, string message)
        {
            return (!boolValue) ?
                new DomainNotification("AssertArgumentTrue", message) : null;
        }

        public static DomainNotification AssertAreEquals(string value, string match, string message)
        {
            return (!(value == match)) ?
                new DomainNotification("AssertArgumentTrue", message) : null;
        }

        public static DomainNotification AssertIsGreaterThan(int value1, int value2, string message)
        {
            return (!(value1 >= value2)) ?
                new DomainNotification("AssertArgumentTrue", message) : null;
        }

        public static DomainNotification AssertIsGreaterThan(decimal value1, decimal value2, string message)
        {
            return (!(value1 > value2)) ?
                new DomainNotification("AssertArgumentTrue", message) : null;
        }

        public static DomainNotification AssertIsGreaterOrEqualThan(int value1, int value2, string message)
        {
            return (!(value1 >= value2)) ?
                new DomainNotification("AssertArgumentTrue", message) : null;
        }

        // validação de data
        public static DomainNotification AssertLessThanDate(DateTime dataValue, string message)
        {
            DateTime dataMinima = DateTime.Now.AddMonths(1);

            return (dataMinima > dataValue) ?
                new DomainNotification("AssertArgumentLength", message) : null;
        }

        // validação de data evolução treino
        public static DomainNotification AssertLessThanDateEvolucao(DateTime dataValue, string message)
        {
            DateTime dataMinima = DateTime.Now.AddMonths(-1);

            return (dataMinima > dataValue) ?
                new DomainNotification("AssertArgumentLength", message) : null;
        }

        // validação de data igual a data do dia
        public static DomainNotification AssertDateEqualToDate(DateTime dataValue, string message)
        {
            //var a = DateTime.Now.Date;

            DateTime data = DateTime.Now.Date;
            //string data2 = data.ToShortDateString();
            //string data3 = dataValue.ToShortDateString();

            return (!data.Equals(dataValue)) ?
                new DomainNotification("AssertArgumentLength", message) : null;
        }

        // validação de senha
        public static DomainNotification AssertLength(string stringValue, int minimum, string message)
        {
            int length = stringValue.Trim().Length;

            return (length < minimum) ?
                new DomainNotification("AssertArgumentLength", message) : null;
        }

        // Afirmar é maior do que. com float
        public static DomainNotification AssertIsGreaterThan(double value1, double value2, string message)
        {
            return (!(value1 > value2)) ?
                new DomainNotification("AssertArgumentTrue", message) : null;
        }

        // Afirmar é maior do que. com float
        public static DomainNotification AssertIsValidEmail(string stringValue, string message)
        {
            bool isValid = false;
            if ((stringValue.Contains("@") && stringValue.Contains(".com")) || (stringValue.Contains("@") && stringValue.Contains(".com.br")))
            {
                isValid = true;
            }

            return (isValid != true) ?
                new DomainNotification("AssertArgumentTrue", message) : null;
        }
    }
}