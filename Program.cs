using System;
namespace JuegoDePokemon
{
    // Clase que representa un Pokémon
    class Pokemon
    {
        public string Nombre { get; set; }
        public int Salud { get; set; }
        public int Ataque { get; set; }
        public int Defensa { get; set; }
        // Constructor que inicializa un Pokémon
        public Pokemon(string nombre, int salud, int ataque, int defensa)
        {
            Nombre = nombre;
            Salud = salud;
            Ataque = ataque;
            Defensa = defensa;

        }
        // Método para atacar a otro Pokémon
        public void Atacar(Pokemon enemigo)
        {
            int daño = Ataque - enemigo.Defensa;
            if (daño < 0) daño = 0;
            enemigo.Salud -= daño;
            Console.WriteLine($"{Nombre} ataca a {enemigo.Nombre} y causa {daño} puntos de daño.");
        }
        // Método para defenderse y reducir el daño del próximo ataque
        public void Defenderse()
        {
            Defensa += 5;
            Console.WriteLine($"{Nombre} se defiende, aumentando su defensa en 5 puntos.");
        }
    }
    // Clase que representa el juego
    class Juego
    {
        private Pokemon jugadorPokemon;
        private Pokemon enemigoPokemon;
        // Método para seleccionar el Pokémon del jugador
        public void SeleccionarPokemon()
        {
            Console.WriteLine("Elige tu Pokémon:");
            Console.WriteLine("1. Charmander");
            Console.WriteLine("2. Squirtle");
            Console.WriteLine("3. Bulbasaur");
            Console.WriteLine("4. Arceus");
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    jugadorPokemon = new Pokemon("Charmander", 65, 15, 5);
                    break;
                case 2:
                    jugadorPokemon = new Pokemon("Squirtle", 70, 10, 10);
                    break;
                case 3:
                    jugadorPokemon = new Pokemon("Bulbasaur", 70, 12, 8);
                    break;
                case 4:
                    jugadorPokemon = new Pokemon("Arceus", 120, 300, 120);
                    break;
                default:
                    Console.WriteLine("Opción no válida, elige Charmander por defecto.");
                    jugadorPokemon = new Pokemon("Charmander", 50, 15, 5);
                    break;
            }
            enemigoPokemon = new Pokemon("Eternatus", 255, 115, 250);
            Console.WriteLine($"Has elegido a {jugadorPokemon.Nombre} para la batalla contra {enemigoPokemon.Nombre}.");
        }
        // Método que inicia la batalla
        public void Batalla()
        {
            while (jugadorPokemon.Salud > 0 && enemigoPokemon.Salud > 0)
            {
                Console.WriteLine($"\n{jugadorPokemon.Nombre} - Salud: {jugadorPokemon.Salud}");
                Console.WriteLine($"{enemigoPokemon.Nombre} - Salud: {enemigoPokemon.Salud}");
                Console.WriteLine("Elige una acción:");
                Console.WriteLine("1. Atacar");
                Console.WriteLine("2. Defenderse");
                int accion = int.Parse(Console.ReadLine());
                switch (accion)
                {
                    case 1:
                        jugadorPokemon.Atacar(enemigoPokemon);
                        break;
                    case 2:
                        jugadorPokemon.Defenderse();
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Perdiste el turno.");
                        break;
                }
                // Turno del enemigo
                enemigoPokemon.Atacar(jugadorPokemon);
            }
            if (jugadorPokemon.Salud <= 0)
            {
                Console.WriteLine($"¡{jugadorPokemon.Nombre} ha sido derrotado! Has perdido la batalla.");
            }
            else
            {
                Console.WriteLine($"¡Has derrotado a {enemigoPokemon.Nombre}! ¡Has ganado la batalla!");
            }
        }

    }
    // Clase principal del programa
    class Program
    {
        static void Main(string[] args)
        {
            Juego juego = new Juego();
            juego.SeleccionarPokemon();
            juego.Batalla();
        }
    }
}
