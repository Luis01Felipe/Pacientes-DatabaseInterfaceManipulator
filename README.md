# Pacientes DIM

O app em sua tela inicial possui os seguintes atributos:
- #### **Rótulos**
	- ID:
	- Nome:
	- Data:
	- Hospital:
	- Chegada:
	- Medicamento:
	- Pré Quimio:
	- Durante a Quimio:
	- Após a Quimio:
	- Observações:
- #### **Campo Texto** 
	- Cada Rótulo possui um respectivo.
- #### **Botões** 
	- Create^[Ira executar um insert no BD] = Adicionar
	- Read^[Irá executar um select baseado no ID puxando para os campos de texto os valores da linha daquele ID.] = Selecionar
	- Update^[Irá dar o comando update para modificar os dados de uma linha baseado em seu valor de ID, sendo este o único não alterável.] = Atualizar
	- Delete^[Irá deletar uma linha apartir do ID.] = Deletar
	- Clear^[Irá limpar os campos de escrita] = Limpar
	- Atualizar Visão^[Este botão ira atualizar a tabela de visão]
	- Ajuda^[Este botão irá explicar o básico do funcionamento do programa]

### Interface
%%Assim que terminar os concertos, colocar a imagem da UI%%

### Funcionamento
Digite os dados a serem inseridos nas caixas de texto correspondentes. O único dado obrigatório a ser preenchido é o ID. Quando terminar, clique em Adicionar. Se desejar visualizar os dados de um paciente específico, insira o ID correspondente e, em seguida, clique em Selecionar. Para atualizar informações, preencha o campo ID com as alterações desejadas e pressione Atualizar. O mesmo procedimento se aplica para excluir informações. O botão Limpar permite remover o texto das caixas de texto. A janela ao lado permite que o usuário visualize todas as informações em tempo real.

## Objetivos
Criar um aplicativo simples e prático que visa se comunicar com o banco de dados através de comandos CRUD e possa acessar o banco de dados em qualquer dispositivo através do Firebase Console.

### A concertar:
- [x] O tbData quando dou o selecionar acaba por trazer a data em um formato estranho
- [x] Não consigo digitar só o ID e algum outro dado e então atualizar.
- [x] Fazer com que o visãoTabela Funcione
- [ ] Arrumar o dgvTableView
	- [ ] Fazer com que mostre o ID;
	- [ ] Impedir de gerar uma linha com todos dados nulos;
	- [ ] Permitir que o usuário possa mudar a visualização de cada coluna entre crescente e decrescente.

### Melhorias: 
- [x] Fazer com que os **Campos Texto ID e Idade** só recebam inteiros.
- [x] Conectar o app com o banco de dados.
- [x] Fazer com que o **Add** Funcione
- [x] Fazer com que o **Read** funcione
- [x] Fazer com que o **Update** funcione
- [x] Fazer com que o **Delete** funcione
- [x] Fazer com que o Executavel funcione sozinho.
- [x] Ao digitar a data no formato dd/mm/yyyy o programa ira adicionar as barras conforme o texto é escrito^[Permitir que o usuário digite apenas números];
- [x] Ao digitar o Horário no formato hh:mm o programa ira adicionar o dois pontos conforme o texto é escrito^[Permitir que o usuário digite apenas números];
- [ ] Permitir que ao selecionar uma linha ele automaticamente puxe os dados dela.
- [ ] Fazer com que ele possa funcionar com qualquer banco de dados.

### Futuro
- [ ] Criar versão para dispositivos móveis.

