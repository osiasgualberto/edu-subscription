# Education Platform by Subscription

<p>Plataforma de educação baseada em assinaturas, integrada ao serviço de pagamento Asaas.</p> 

## Regras de negócio

- [ ] O sistema deve ser capaz de cadastrar, listar e atualizar planos de assinaturas (apenas administradores);
- [ ] O sistema deve ser capaz de cadastrar, listar e atualizar cursos e aulas (apenas administradores);
- [ ] O sistema deve ser capaz de cadastrar, listar e atualizar usuários/membros (todos usuários);
- [ ] O sistema deve ser capaz de cadastrar registros de pagamentos locais (apenas por meio do evento de assinatura criada);
- [ ] O sistema não deve permitir o acesso de membros à cursos não autorizados (por meio da assinatura atual);
- [ ] O sistema deve ser capaz de permitir ao usuário escolher uma assinatura dentre as disponíveis;
- [ ] O sistema deve ser capaz de enviar a cobrança de acordo com o pagamento escolhido;

## Checklist

- [ ] Implementar todos os CRUDs;
- [ ] Validar os dados de entrada das requisições dos casos de uso;
- [ ] Realizar testes unitários em todos os casos de uso;
- [x] Integrar a geração da cobrança com o Asaas (uma cobrança ou várias);
- [x] Usar pelo menos um evento de domínio;
- [x] Utilizar o Outbox Pattern;
- [x] Integrar um framework de logs;
- [ ] Estudar sobre Webhooks e aplicá-los no projeto;