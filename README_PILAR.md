README 

4PILAR

Eae Pilar blz?

Então é o seguinte se prestar atenção no arquivo json nossas strings de conexão estão diferentes! Então recomendo que quando der um git pull você troque as strings de conexão no 

**App settings json**


E application DBContext adicionei a conexão com o banco de dados por injeção de dependência Você pode perceber isso nas linhas 9 e 20 

na linha 20 você pode ver que eu já inicializo o códiugo com this._configuration utilizamos isso para não termos que colocar a string inteira sabe?

Bom foi isso que realizei no código e como pode ver retirei os controles de weather já que são desnecessários

Bom código 