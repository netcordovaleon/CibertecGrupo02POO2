namespace CiberStore.Extensiones
{
    public static class DateTimeExtension
    {

        public static string GetPeruDateTimeFormat(this DateTime dateTime)
        {

            return dateTime.ToString("dd/MM/yyyy");

        }

    }
}
