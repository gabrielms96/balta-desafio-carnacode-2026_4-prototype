using DesignPatternChallengePrototype.ConcretePrototype;
using DesignPatternChallengePrototype.Service;

namespace DesignPatternChallengePrototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Templates de Documentos com Padrão Prototype ===\n");

            var service = new DocumentService();

            Console.WriteLine("\n" + new string('=', 70));
            Console.WriteLine("DEMONSTRAÇÃO 1: Performance - Criando 5 contratos de serviço");
            Console.WriteLine(new string('=', 70) + "\n");

            var startTime = DateTime.Now;

            for (int i = 1; i <= 5; i++)
            {
                // Clonando do protótipo (rápido!) em vez de criar do zero
                var contract = service.CreateServiceContract();

                // Personalizando o clone para cada cliente
                contract.Title = $"Contrato #{i} - Cliente ABC-{i}";
                contract.Metadata["NumeroContrato"] = $"CT-2026-{i:000}";
                contract.Metadata["DataCriacao"] = DateTime.Now.ToString();
            }

            var elapsed = (DateTime.Now - startTime).TotalMilliseconds;
            Console.WriteLine($"\nTempo total: {elapsed}ms");
            Console.WriteLine("Os 5 contratos foram clonados rapidamente!\n");

            var contrato1 = service.CreateServiceContract();
            contrato1.Title = "Contrato Cliente XYZ";

            var contrato2 = service.CreateServiceContract();
            contrato2.Title = "Contrato Cliente ABC";

            contrato2.Sections.Add(new Section
            {
                Name = "Cláusula 4 - Garantias",
                Content = "O contratado garante...",
                IsEditable = true
            });
            contrato2.Tags.Add("garantias");
            contrato2.Workflow.Approvers.Add("diretor@empresa.com");

            Console.WriteLine("Contrato 1:");
            service.DisplayTemplate(contrato1);

            Console.WriteLine("\nContrato 2 (com modificações):");
            service.DisplayTemplate(contrato2);

            Console.WriteLine("\n✓ Sucesso! O contrato1 não foi afetado pelas modificações no contrato2");
            Console.WriteLine($"  Contrato 1 tem {contrato1.Sections.Count} seções");
            Console.WriteLine($"  Contrato 2 tem {contrato2.Sections.Count} seções");

            Console.WriteLine("\n" + new string('=', 70));
            Console.WriteLine("DEMONSTRAÇÃO 3: Diferentes tipos de protótipos");
            Console.WriteLine(new string('=', 70) + "\n");

            var servicoContrato = service.CreateServiceContract();
            servicoContrato.Title = "Contrato Serviço - Cliente DEF";

            var consultoriaContrato = service.CreateConsultingContract();
            consultoriaContrato.Title = "Contrato Consultoria - Cliente GHI";

            Console.WriteLine("Contrato de Serviço:");
            service.DisplayTemplate(servicoContrato);

            Console.WriteLine("\nContrato de Consultoria:");
            service.DisplayTemplate(consultoriaContrato);

        }
    }
}