# Exoplanets

# Autoria

## Autores

Pedro Oliveira - 21705187

Sara Gama - 21705494

## Repartição do Projecto

Pedro Oliveira - O envolvimento foi feito através das classes _EntityGenerator_, 
_FileManager_, _NumericFilter_, _StringFilter_, _TableManager_, _Star_ e _Planet_ 
e as interefaces _IEntity_, _IFilter_.

Sara Gama - O envolvimento no projecto é mostrado através da realização de algumas 
classes como o DrawMenu para desenhar o Menu do programa, DrawTable realiza a base 
das linhas da tabela, Planet e Star apenas coloquei a informação base sobre os mesmos; 
ainda executou o makdown e o uml (repartido).


## Repositório Remoto

[LP2_Exoplanets_2020]()

# Arquitectura da solução

## Indicação da forma de implementação 

Decidimos implementar uma consola interactiva.

## Descrição da solução

O programa foi feito de maneira a que o utilizador tenha acesso somente as informações a 
partir do _MenuDrawer_. A classe _MenuDrawer_ utiliza os métodos das classes _abstract_ 
para fazer o gerenciamento de todas as informações necessárias para que o utilizador tenha 
o mínimo de dificuldade para fazer as pesquisas, sendo necessário utilizar as informações 
passadas em casa menu. Dessa maneira protegemos a informação passada pelo menu das alterações
assim como mantemos o programa simples com todas as funções necessárias.
As coleções utilizadas foram coleções genéricas para melhor gestão de variáveis e para manter
as regras do sistema _SOLID_.
Uma das maneiras que utilizamos como optimização do código foi não utilizar o _loop foreach_
para levar em consideração a grande quantidade de valores que pode ser passada pelo arquivo 
_.csv_ para serem lidos.

## Diagrama UML 

![UML](https://github.com/serapinta/LP2_Exoplanets_2020/blob/main/Imagens/UML)

# Referências

[Slides e aulas fornecidas pelo professor](https://github.com/VideojogosLusofona/lp2_2020_aulas)

[StackOverFlow - Converting String To Float in C#](https://stackoverflow.com/questions/11202673/converting-string-to-float-in-c-sharp)

[.NET Api browser - switch (C# reference)](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/switch)
