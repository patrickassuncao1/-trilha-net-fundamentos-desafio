namespace Challenge.Models
{
    public class Parking
    {
        private decimal initialPrice = 0;
        private decimal pricePerHour = 0;
        private List<string> vehicles = new List<string>();

        public Parking(decimal initialPrice, decimal pricePerHour)
        {
            this.initialPrice = initialPrice;
            this.pricePerHour = pricePerHour;
        }
        public void AddVehicle()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string vehiclePlate = $"{Console.ReadLine()}";

            while (!ValidateLicensePlate.Validate(vehiclePlate))
            {
                Console.WriteLine("Placa Inválida, Digite Novamente: ");
                vehiclePlate = $"{Console.ReadLine()}";
            }

            this.vehicles.Add(vehiclePlate);

        }

        public void RemoveVehicle()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string vehiclePlate = $"{Console.ReadLine()}";

            bool isVehicle = this.vehicles.Any(plate => plate.ToUpper() == vehiclePlate.ToUpper());

            if (isVehicle)
            {
                int hours = 0;
                decimal amount = 0;


                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
                hours = Convert.ToInt32(Console.ReadLine());

                amount = this.initialPrice + (hours * this.pricePerHour);
                this.vehicles.Remove(vehiclePlate);

                Console.WriteLine($"O veículo {vehiclePlate} foi removido e o preço total foi de: R$ {amount}");

            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListVehicles()
        {
            if (this.vehicles.Any())
            {
                int count = 1;
                Console.WriteLine("Os veículos estacionados são:");

                foreach (string item in this.vehicles)
                {
                    Console.WriteLine($"{count}°: {item} ");

                    count++;
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}