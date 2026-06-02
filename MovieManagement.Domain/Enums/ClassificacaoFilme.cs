namespace MovieManagement.Domain.Enums
{
    public enum ClassificacaoFilme // Utilização de Enum para limitar os valores possíveis da classificação,
                                   // aumentando a legibilidade do código e evitando valores inválidos. 
    {
        MuitoMau = 0,
        Mau = 1,
        Razoavel = 2,
        Bom = 3,
        MuitoBom = 4,
        Excelente = 5
    }
}

//Decidi utilizar um Enum porque a classificação do filme tem um conjunto fechado de opções - 0-5.
//Em vez de guardar apenas números inteiros, o código torna-se mais legível, mais seguro e mais fácil de manter.
//Evita também a utilização de valores  fora do intervalo definido. 
