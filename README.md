# RarExtractor

`RarExtractor` é um programa simples em C# projetado para extrair arquivos de arquivos RAR. Ele oferece uma interface gráfica do usuário (GUI) básica para selecionar diretórios, extrair arquivos RAR e realizar operações opcionais, como excluir os arquivos RAR originais ou renomear determinados arquivos.

## Recursos

- **Seleção de Diretórios:** Escolha diretórios nos quais os arquivos RAR serão extraídos.
- **Extração de Arquivos:** Extrai arquivos de arquivos RAR, preservando caminhos e carimbos de data e hora.
- **Operações Opcionais:** Exclua os arquivos RAR originais e renomeie arquivos específicos, se desejado.
- **Interface Amigável:** GUI básica para facilitar o uso.

## Uso

1. Inicie o programa.
2. Clique no botão "Obtem Diretórios" para selecionar diretórios contendo arquivos RAR.
3. Escolha operações opcionais:
   - Marque "Deletar compactados" para excluir os arquivos RAR originais após a extração.
   - Marque "Renomear padrão" para renomear arquivos específicos em diretórios que contenham "Control" no nome.
4. Clique no botão "Processar" para iniciar o processo de extração.
5. Monitore o progresso por meio da barra de progresso e das mensagens.

## Dependências

- Biblioteca [SharpCompress](https://github.com/adamhathcock/sharpcompress) para manipulação de arquivos RAR.

## Instalação

1. Clone ou baixe o repositório.
2. Compile o projeto usando um IDE C# como o Visual Studio.

## Configuração

Nenhuma configuração específica é necessária. No entanto, certifique-se de incluir a biblioteca SharpCompress em seu projeto.

## Autores

- [Igor Leite](https://github.com/igleite)
- [Washington Pereira](https://github.com/WLpereira)

## Licença

Este programa é de código aberto e está disponível sob a [Licença MIT](LICENSE).

## Aviso Legal

Este programa não possui garantia. Use por sua própria conta e risco.
