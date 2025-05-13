
const decimal PRECO_PRIMEIRA_HORA = 20;
const decimal PRECO_HORA_PEQUENO = 10;
const decimal PRECO_HORA_GRANDE = 20;
const decimal PRECO_DIARIA_PEQUENO = 50;
const decimal PRECO_DIARIA_GRANDE = 80;
const decimal PRECO_LAVAGEM_PEQUENO = 50;
const decimal PRECO_LAVAGEM_GRANDE = 100;
const double ADICIONAL_VALET = 0.2;


const int TEMPO_DIARIA = 5 * 60;            
const int TEMPO_TOLERANCIA = 5;             
const int MAX_TEMPO_PERMANENCIA = 12 * 60;  


int tempoPermanencia;
string tamanho;
bool valet, lavagem;


decimal precoEstacionamento = 0;
decimal precoValet = 0;
decimal precoLavagem = 0;
decimal total = 0;


Console.WriteLine("--- Estacionamento ---\n");

Console.Write("Tamanho do veículo (P/G).....: ");
tamanho = Console.ReadLine()!.Trim().Substring(0, 1).ToUpper();

if (tamanho != "P" && tamanho != "G")
{
    Console.WriteLine("Tamanho inválido.");
    return;
}

Console.Write("Tempo de permanência (min)...: ");
tempoPermanencia = Convert.ToInt32(Console.ReadLine());

if (tempoPermanencia <= 0 || tempoPermanencia > MAX_TEMPO_PERMANENCIA)
{
    Console.WriteLine("Tempo de permanência inválido.");
    return;
}

Console.Write("Serviço de valet (S/N).......: ");
valet = Console.ReadLine()!.Trim().Substring(0, 1).ToUpper() == "S";

Console.Write("Serviço de lavagem (S/N).....: ");
lavagem = Console.ReadLine()!.Trim().Substring(0, 1).ToUpper() == "S";

if (tempoPermanencia >= TEMPO_DIARIA)
{
    precoEstacionamento = (tamanho == "P") ? PRECO_DIARIA_PEQUENO : PRECO_DIARIA_GRANDE;
}
else
{
    int horas = tempoPermanencia / 60;
    int minutos = tempoPermanencia % 60;

    if (minutos > TEMPO_TOLERANCIA)
        horas++;

    precoEstacionamento = PRECO_PRIMEIRA_HORA;

    int horasAdicionais = horas - 1;
    if (horasAdicionais > 0)
    {
        decimal precoHora = (tamanho == "P") ? PRECO_HORA_PEQUENO : PRECO_HORA_GRANDE;
        precoEstacionamento += horasAdicionais * precoHora;
    }
}


if (valet)
{
    precoValet = precoEstacionamento * Convert.ToDecimal(ADICIONAL_VALET);
}


if (lavagem)
{
    precoLavagem = (tamanho == "P") ? PRECO_LAVAGEM_PEQUENO : PRECO_LAVAGEM_GRANDE;
}

total = precoEstacionamento + precoValet + precoLavagem;


Console.WriteLine($"\nEstacionamento..: {precoEstacionamento,14:C}");
Console.WriteLine($"Valet...........: {precoValet,14:C}");
Console.WriteLine($"Lavagem.........: {precoLavagem,14:C}");
Console.WriteLine("--------------------------------");
Console.WriteLine($"Total...........: {total,14:C}");