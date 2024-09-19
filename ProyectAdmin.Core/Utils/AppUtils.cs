namespace ProyectAdmin.Core.Utils
{
    public static class AppUtils
    {
        public static string CapitalizeFirstLetter(string input)
        {
            return string.IsNullOrEmpty(input) ? input : char.ToUpper(input[0]) + input.Substring(1);
        }


        /// <summary>
        /// Verifica si una clase posee la propiedad recibida en el parametro 
        /// </summary>
        /// <typeparam name="T">Clase para buscar propiedad</typeparam>
        /// <param name="propertyName">Propiedad a buscar</param>
        /// <returns></returns>
        public static bool HasProperty<T>(string propertyName)
        {
            return typeof(T).GetProperty(propertyName) != null;
        }
    }
}
