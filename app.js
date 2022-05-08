





class Pessoa {
    constructor() {
        this._nome = '';
        this._idade = 0;
    }
    get nome() { return this._nome }
    set nome(n) { this._nome = n }
    get idade() { return this._idade }
    set idade(n) { this._idade = n}
}

class Pessoa3 {
    constructor() {
        this._nome = '';
        this._idade = 0;
    }
    get nome() { return this._nome }
    set nome(n) { this._nome = n }
    get idade() { return this._idade }
    set idade(n) { this._idade = n}
}



function Pessoa2() {
    this.nome = '';
    this.idade = 0;
    return this;
}




let p1 = {
    nome: 'Bruno',
    idade: 15
}



let p2 = new Pessoa();
p2.nome = 'Bruno';
p2.idade = 15;



let p3 = new Pessoa2();
p3.nome = 'Bruno';
p3.idade = 15;



let p4 = new Pessoa2();




ola(p1);
ola(p2);
ola(p3);
ola(p4);
