using DesignPatternChallenge.Services;

class Program
    {
        static void Main(string[] args)
        {
            var service = new DocumentService();

            // ── DEMO 1: Performance ─────────────────────────────────────

            Console.WriteLine("Criando 5 contratos de serviço (com clonagem)...");
            var startTime = DateTime.Now;

            for (int i = 1; i <= 5; i++)
            {
                // Agora CreateServiceContract() clona o protótipo
                var contract = service.CreateServiceContract();
                contract.Title = $"Contrato #{i} - Cliente {i}";
            }

            var elapsed = (DateTime.Now - startTime).TotalMilliseconds;
            Console.WriteLine($"⏱️  Tempo total: {elapsed}ms - Com prootyp");

            // ── DEMO 2: Independência dos clones ────────────────────────
            
            var clone1 = service.CreateServiceContract();
            var clone2 = service.CreateServiceContract();

            clone2.Title = "Título Completamente Diferente";
            clone2.Sections[0].Content = "Conteúdo alterado no clone2";
            clone2.Workflow.Approvers.Add("extra@empresa.com");

            Console.WriteLine($"\nclone1.Title: {clone1.Title}");
            Console.WriteLine($"clone2.Title: {clone2.Title}");
            Console.WriteLine($"\nclone1 - Seção 1: {clone1.Sections[0].Content}");
            Console.WriteLine($"clone2 - Seção 1: {clone2.Sections[0].Content}");
            Console.WriteLine($"\nclone1 - Aprovadores: {clone1.Workflow.Approvers.Count}");
            Console.WriteLine($"clone2 - Aprovadores: {clone2.Workflow.Approvers.Count}");
            Console.WriteLine("\n✅ clone1 não foi afetado pelas mudanças no clone2!\n");

            // ── DEMO 3: Código original funciona igual ───────────────────

            var consultingContract = service.CreateConsultingContract();
            service.DisplayTemplate(consultingContract);
        }
    }