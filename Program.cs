static Random rng = new Random();

        class Personagem
        {
            public int Habilidade { get; set; }
            public int Energia { get; set; }
            public int Sorte { get; set; }

            public Personagem()
            {
                Habilidade = rng.Next(1, 7) + 6;
                Energia = rng.Next(1, 7) + 6;
                Sorte = rng.Next(1, 7) + rng.Next(1, 7) + 12;
            }

            public bool TestarSorte()
            {
                int teste = rng.Next(1, 7) + rng.Next(1, 7);
                bool sortudo = teste <= Sorte;
                Sorte = Math.Max(0, Sorte - 1); // Reduz sorte após uso
                return sortudo;
            }

            public int ForcaAtaque()
            {
                return rng.Next(1, 7) + rng.Next(1, 7) + Habilidade;
            }
        }

        class Criatura
        {
            public string Nome { get; }
            public int Habilidade { get; }
            public int Energia { get; set; }

            public Criatura(string nome, int habilidade, int energia)
            {
                Nome = nome;
                Habilidade = habilidade;
                Energia = energia;
            }

            public int ForcaAtaque()
            {
                return rng.Next(1, 7) + rng.Next(1, 7) + Habilidade;
            }
        }

        static void Main(string[] args)
        
            Personagem heroi = new Personagem();
            Console.WriteLine("Seu personagem:");
            Console.WriteLine($"Habilidade: {heroi.Habilidade}");
            Console.WriteLine($"Energia: {heroi.Energia}");
            Console.WriteLine($"Sorte: {heroi.Sorte}");
            Console.WriteLine();

            Criatura[] inimigos = new Criatura[]
            {
                new Criatura("Lobo Cinzento", 3, 3),
                new Criatura("Lobo Branco", 3, 3),
                new Criatura("Goblin", 5, 4),
                new Criatura("Orc Vesgo", 5, 5),
                new Criatura("Orc Barbudo", 5, 5),
                new Criatura("Zumbi Manco", 6, 7),
                new Criatura("Zumbi Balofo", 6, 7),
                new Criatura("Troll", 8, 7),
                new Criatura("Ogro", 8, 9),
                new Criatura("Ogro Furioso", 10, 9),
                new Criatura("Necromante Maligno", 12, 12)
            };

            foreach (var inimigo in inimigos)
            {
                Console.WriteLine($"\nVocê enfrenta: {inimigo.Nome} (Habilidade: {inimigo.Habilidade}, Energia: {inimigo.Energia})");

                while (heroi.Energia > 0 && inimigo.Energia > 0)
                {
                    int forcaHeroi = heroi.ForcaAtaque();
                    int forcaInimigo = inimigo.ForcaAtaque();

                    Console.WriteLine($"\nForça de ataque: Herói = {forcaHeroi}, {inimigo.Nome} = {forcaInimigo}");

                    if (forcaHeroi > forcaInimigo)
                    {
                        Console.Write("Você venceu a rodada! Deseja testar sua sorte para causar mais dano? (s/n): ");
                        string escolha = Console.ReadLine().ToLower();

                        int dano;
                        if (escolha == "s")
                        {
                            bool sortudo = heroi.TestarSorte();
                            dano = sortudo ? 4 : 1;
                            Console.WriteLine(sortudo ? "Você foi sortudo! Causou 4 de dano." : "Você foi azarado... Causou apenas 1 de dano.");
                        }
                        else
                        {
                            dano = 2;
                        }

                        inimigo.Energia -= dano;
                        Console.WriteLine($"{inimigo.Nome} agora tem {Math.Max(0, inimigo.Energia)} de energia.");
                    }
                    else if (forcaInimigo > forcaHeroi)
                    {
                        Console.Write("Você perdeu a rodada! Deseja testar sua sorte para tentar sofrer menos dano? (s/n): ");
                        string escolha = Console.ReadLine().ToLower();

                        int dano;
                        if (escolha == "s")
                        {
                            bool sortudo = heroi.TestarSorte();
                            dano = sortudo ? 1 : 3;
                            Console.WriteLine(sortudo ? "Você foi sortudo! Sofreu apenas 1 de dano." : "Você foi azarado... Sofreu 3 de dano.");
                        }
                        else
                        {
                            dano = 2;
                        }

                        heroi.Energia -= dano;
                        Console.WriteLine($"Você agora tem {Math.Max(0, heroi.Energia)} de energia.");
                    }
                    else
                    {
                        Console.WriteLine("Empate! Ninguém acertou.");
                    }
                }

                if (heroi.Energia <= 0)
                {
                    Console.WriteLine("\nVocê foi derrotado! Fim da aventura.");
                    return;
                }

                Console.WriteLine($"Você derrotou o {inimigo.Nome}!");
            }

            Console.WriteLine("\nParabéns! Você derrotou todos os inimigos e completou sua aventura!");
        
    


