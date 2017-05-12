namespace ConhecendoUsandoLiteDb
{
using LiteDB;

public class Agenda
{
    [BsonId]
    public int Id { get; set; }

    [BsonIndex]
    public string Nome { get; set; }

    [BsonIndex]
    public string Email { get; set; }

    public string Telefone { get; set; }
}
}
