bool isResponseGiven = false;
int counter = 0;
var response = "";
int parsedResult;

Console.WriteLine("Hola!");

Tuple<int, bool> panelSolarLadoA = preguntaAlUsuario('a');
isResponseGiven = false;
Tuple<int, bool> panelSolarLadoB = preguntaAlUsuario('b');
isResponseGiven = false;
Tuple<int, bool> techoLadoX = preguntaAlUsuario('x');
isResponseGiven = false;
Tuple<int, bool> techoLadoZ = preguntaAlUsuario('z');

int result = areaRectangulo(techoLadoX.Item1, techoLadoZ.Item1) / areaRectangulo(panelSolarLadoA.Item1, panelSolarLadoB.Item1);
Console.WriteLine($"En el techo de dimensiones {techoLadoX.Item1} y {techoLadoZ.Item1} caben {result} paneles solares de " +
        $"dimensiones {panelSolarLadoA.Item1} y {panelSolarLadoB.Item1}");
Console.WriteLine($"Gracias por utilizar nuestro sistema. Hasta pronto!");

Tuple<int, bool> preguntaAlUsuario(char lado)
{
    while (isResponseGiven == false)
    {
        if (counter > 0)
        {
            Console.WriteLine("No me has entregado un valor numérico. Sin él no podré realizar el cálculo de cuántos paneles solares caben en tu techo.\n");
        }

        switch (lado)
        {
            case 'a' or 'b':
                Console.WriteLine($"Escribe la longitud del lado {lado} de tu panel solar.");
                response = Console.ReadLine();
                break;
            case 'x' or 'z':
                Console.WriteLine($"Escribe la longitud del lado {lado} del techo en el que quieres colocar los paneles solares.");
                response = Console.ReadLine();
                break;
        }


        // Si response no es nulo, ni letras ni string vacío
        if (response is not null && int.TryParse(response, out parsedResult))
        {
            counter = 0;
            isResponseGiven = true;
            return Tuple.Create(parsedResult, isResponseGiven);
        }
        else
        {
            counter++;
        }
    }
    return Tuple.Create(0, false);
}
int areaRectangulo(int a, int b)
{
    return a * b;
}