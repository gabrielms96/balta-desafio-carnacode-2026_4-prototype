using DesignPatternChallengPrototype.ConcretePrototype;

namespace DesignPatternChallengPrototype.Service
{
    public class DocumentService
    {
        private DocumentTemplate _serviceContractPrototype;
        private DocumentTemplate _consultingContractPrototype;

        public DocumentService()
        {
            InitializePrototypes();
        }

        private void InitializePrototypes()
        {
            Console.WriteLine("Inicializando protótipos de templates (apenas uma vez)...\n");

            // Criar o protótipo de Contrato de Serviço
            _serviceContractPrototype = CreateServiceContractPrototype();

            // Criar o protótipo de Contrato de Consultoria
            _consultingContractPrototype = CreateConsultingContractPrototype();
        }

        private DocumentTemplate CreateServiceContractPrototype()
        {
            Console.WriteLine("Criando PROTÓTIPO de Contrato de Serviço...");
            System.Threading.Thread.Sleep(100); // Simula processo demorado

            var template = new DocumentTemplate
            {
                Title = "Contrato de Prestação de Serviços",
                Category = "Contratos",
                Style = new DocumentStyle
                {
                    FontFamily = "Arial",
                    FontSize = 12,
                    HeaderColor = "#003366",
                    LogoUrl = "https://company.com/logo.png",
                    PageMargins = new Margins { Top = 2, Bottom = 2, Left = 3, Right = 3 }
                },
                Workflow = new ApprovalWorkflow
                {
                    RequiredApprovals = 2,
                    TimeoutDays = 5
                }
            };

            template.Workflow.Approvers.Add("gerente@empresa.com");
            template.Workflow.Approvers.Add("juridico@empresa.com");

            template.Sections.Add(new Section
            {
                Name = "Cláusula 1 - Objeto",
                Content = "O presente contrato tem por objeto...",
                IsEditable = true
            });
            template.Sections.Add(new Section
            {
                Name = "Cláusula 2 - Prazo",
                Content = "O prazo de vigência será de...",
                IsEditable = true
            });
            template.Sections.Add(new Section
            {
                Name = "Cláusula 3 - Valor",
                Content = "O valor total do contrato é de...",
                IsEditable = true
            });

            template.RequiredFields.Add("NomeCliente");
            template.RequiredFields.Add("CPF");
            template.RequiredFields.Add("Endereco");

            template.Tags.Add("contrato");
            template.Tags.Add("servicos");

            template.Metadata["Versao"] = "1.0";
            template.Metadata["Departamento"] = "Comercial";

            return template;
        }

        private DocumentTemplate CreateConsultingContractPrototype()
        {
            Console.WriteLine("Criando PROTÓTIPO de Contrato de Consultoria...");
            System.Threading.Thread.Sleep(100); // Simula processo demorado

            var template = new DocumentTemplate
            {
                Title = "Contrato de Consultoria",
                Category = "Contratos",
                Style = new DocumentStyle
                {
                    FontFamily = "Arial",
                    FontSize = 12,
                    HeaderColor = "#003366",
                    LogoUrl = "https://company.com/logo.png",
                    PageMargins = new Margins { Top = 2, Bottom = 2, Left = 3, Right = 3 }
                },
                Workflow = new ApprovalWorkflow
                {
                    RequiredApprovals = 2,
                    TimeoutDays = 5
                }
            };

            template.Workflow.Approvers.Add("gerente@empresa.com");
            template.Workflow.Approvers.Add("juridico@empresa.com");

            template.Sections.Add(new Section
            {
                Name = "Cláusula 1 - Objeto",
                Content = "O presente contrato de consultoria tem por objeto...",
                IsEditable = true
            });
            template.Sections.Add(new Section
            {
                Name = "Cláusula 2 - Prazo",
                Content = "O prazo de vigência será de...",
                IsEditable = true
            });

            template.RequiredFields.Add("NomeCliente");
            template.RequiredFields.Add("CPF");
            template.RequiredFields.Add("Endereco");

            template.Tags.Add("contrato");
            template.Tags.Add("consultoria");

            template.Metadata["Versao"] = "1.0";
            template.Metadata["Departamento"] = "Comercial";

            return template;
        }

        // Métodos públicos que usam o padrão Prototype (clonagem rápida)
        public DocumentTemplate CreateServiceContract()
        {
            Console.WriteLine("Clonando contrato de serviço a partir do protótipo...");
            return (DocumentTemplate)_serviceContractPrototype.Clone();
        }

        public DocumentTemplate CreateConsultingContract()
        {
            Console.WriteLine("Clonando contrato de consultoria a partir do protótipo...");
            return (DocumentTemplate)_consultingContractPrototype.Clone();
        }

        public void DisplayTemplate(DocumentTemplate template)
        {
            Console.WriteLine($"\n=== {template.Title} ===");
            Console.WriteLine($"Categoria: {template.Category}");
            Console.WriteLine($"Seções: {template.Sections.Count}");
            Console.WriteLine($"Campos obrigatórios: {string.Join(", ", template.RequiredFields)}");
            Console.WriteLine($"Aprovadores: {string.Join(", ", template.Workflow.Approvers)}");
            Console.WriteLine($"Tags: {string.Join(", ", template.Tags)}");
        }
    }
}

