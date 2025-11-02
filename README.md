# CATI - Central de Atendimento de Tecnologia e Informação

Sistema web para abertura, acompanhamento e gestão de chamados técnicos, desenvolvido com ASP.NET Core MVC. O projeto possui dois perfis de usuário: **Cliente** e **Técnico**, cada um com funcionalidades específicas e dashboards personalizados.

## 🚀 Funcionalidades

### 👤 Cliente
- Abrir chamado técnico
- Consultar chamados em aberto
- Cancelar ou reiterar solicitações
- Adicionar observações e atualizar dados de contato
- Atualizar dados da conta (senha, email, telefone, endereço)

### 🛠️ Técnico
- Visualizar chamados em fila
- Atender chamados em andamento
- Consultar chamados resolvidos e fechados
- Estatísticas mensais de atendimento
- Atualizar dados da conta e setor de atuação

## 🎨 Interface
- Layout moderno e responsivo
- Dashboards com cards intuitivos e emojis
- Rodapé institucional adaptativo em todas as telas

## 🧰 Tecnologias utilizadas
- ASP.NET Core MVC (.NET 9)
- Razor Pages
- Entity Framework (em breve)
- HTML5, CSS3, Bootstrap
- Visual Studio Code

## 📂 Estrutura de pastas
ChamadosIA/ 
├── Controllers/ 
│   
├── ContaController.cs 
│   ├── ClienteController.cs 
│   └── TecnicoController.cs 
├── Models/ 
│   ├── Usuario.cs 
│   └── Chamado.cs (em breve) 
├── Views/ 
│   ├── Conta/ 
│   
├── Cliente/ 
│   └── Tecnico/ 
├── wwwroot/ 
│   └── css/ 
│       └── site.css

## 📄 Licença
Projeto acadêmico e institucional. Desenvolvido pela equipe do CATI.