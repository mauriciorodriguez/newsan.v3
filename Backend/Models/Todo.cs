namespace Backend.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public byte[] Archivo { get; set; }
        public string ArchivoTipo { get; set; }
        public string ArchivoNombre { get; set; }
    }
}
