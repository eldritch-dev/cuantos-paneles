bool isResponseGiven = false;
int counter = 0;
var response = "";

// Configuramos la cultura local y el estilo de número esperado para control de separador de decimales en respuestas del usuario
System.IFormatProvider cultureCL = new System.Globalization.CultureInfo("es-CL");
System.Globalization.NumberStyles numberStyle = System.Globalization.NumberStyles.Float;

Console.WriteLine("Hola!");

// Se pregunta al usuario por las dimensiones del panel solar elegido y de su techo
Tuple<float, bool> panelSolarLadoA = preguntaAlUsuario('a');
isResponseGiven = false;
Tuple<float, bool> panelSolarLadoB = preguntaAlUsuario('b');
isResponseGiven = false;
Tuple<float, bool> techoLadoX = preguntaAlUsuario('x');
isResponseGiven = false;
Tuple<float, bool> techoLadoZ = preguntaAlUsuario('z');

// Se calcula cuántos paneles caben en el techo truncando el resultado mostrado por pantalla, porque se asume que no se pueden utilizar fracciones de panel solar.
float result = areaRectangulo(techoLadoX.Item1, techoLadoZ.Item1) / areaRectangulo(panelSolarLadoA.Item1, panelSolarLadoB.Item1);
Console.WriteLine($"En el techo de dimensiones {techoLadoX.Item1} y {techoLadoZ.Item1} caben {Math.Truncate(result)} paneles solares de " +
        $"dimensiones {panelSolarLadoA.Item1} y {panelSolarLadoB.Item1}");
Console.WriteLine($"Gracias por utilizar nuestro sistema. Hasta pronto!");

// Función que almacena respuesta del largo de un lado de un panel solar o del techo, dependiendo del parámetro de entrada
Tuple<float, bool> preguntaAlUsuario(char lado)
{
    while (isResponseGiven == false)
    {
        if (counter > 0)
        {
            Console.WriteLine("No me has entregado un valor numérico válido. Sin él no podré realizar el cálculo de cuántos paneles solares caben en tu techo.\n" +
                "Considera que si la longitud que me vas a dar es un número decimal, debe contener un separador de decimales de coma para ser válido.\n");
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
        if (response is not null && float.TryParse(response,  numberStyle, cultureCL, out float parsedResult))
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
    return Tuple.Create(0.00f, false);
}

float areaRectangulo(float a, float b)
{
    return a * b;
}