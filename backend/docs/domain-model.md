# KM One Connect — Modelo de Domínio Inicial

## Produto

O KM One Connect é uma plataforma para aluguel de carros entre motoristas de aplicativo.

## Problema

Motoristas que querem trabalhar com aplicativos como Uber e 99 nem sempre possuem um carro disponível.

Ao mesmo tempo, proprietários ou outros motoristas podem ter veículos disponíveis para locação.

## Solução

Criar uma plataforma onde proprietários anunciam veículos disponíveis para aluguel e motoristas interessados solicitam esses veículos por um período determinado.

---

## Fluxo principal

1. Um Driver cadastra um Vehicle.
2. Um Vehicle pode ser anunciado através de uma RentalOffer.
3. Outro Driver pode criar uma RentalRequest para essa oferta.
4. O proprietário pode aceitar ou recusar a solicitação.
5. Uma solicitação aceita pode gerar um RentalContract.

---

## Entidades iniciais

### Driver

Representa um motorista ou proprietário dentro da plataforma.

Responsabilidades iniciais:

- identificar o usuário;
- armazenar nome;
- armazenar documento;
- indicar se está verificado;
- futuramente representar reputação.

---

### Vehicle

Representa um veículo disponível ou potencialmente disponível para aluguel.

Responsabilidades iniciais:

- identificar o veículo;
- armazenar placa;
- armazenar modelo;
- armazenar marca;
- armazenar ano;
- pertencer a um proprietário.

---

### RentalOffer

Representa uma oferta de aluguel de um veículo.

Responsabilidades iniciais:

- identificar a oferta;
- apontar para o veículo;
- apontar para o proprietário;
- definir valor da diária;
- definir valor de caução;
- definir período disponível;
- indicar status da oferta.

---

### RentalRequest

Representa uma solicitação de aluguel feita por um motorista interessado.

Responsabilidades iniciais:

- identificar a solicitação;
- apontar para a oferta;
- apontar para o motorista solicitante;
- definir período solicitado;
- indicar status da solicitação.

---

### RentalContract

Representa um contrato gerado a partir de uma solicitação aceita.

Responsabilidades iniciais:

- identificar o contrato;
- apontar para a oferta;
- apontar para o motorista;
- apontar para o proprietário;
- definir período contratado;
- definir valor total;
- indicar status do contrato.

---

## Value Objects iniciais

### Money

Representa valores monetários.

Exemplos:

- diária;
- caução;
- valor total;
- pagamento.

---

### RentalPeriod

Representa o período de aluguel.

Exemplos:

- data inicial;
- data final;
- quantidade de dias.

---

### Location

Representa uma localização.

Exemplos:

- cidade;
- estado;
- bairro.

---

## Regras iniciais de negócio

1. Uma oferta precisa estar vinculada a um veículo.
2. Uma oferta precisa ter uma diária maior que zero.
3. Uma oferta precisa ter um período válido.
4. Um motorista não pode solicitar a própria oferta.
5. Uma solicitação só pode ser feita para uma oferta ativa.
6. Uma solicitação aceita pode gerar um contrato.
7. Uma oferta encerrada não pode receber novas solicitações.

---

## Casos de uso iniciais

- Criar oferta de aluguel.
- Buscar oferta por ID.
- Listar ofertas disponíveis.
- Criar solicitação de aluguel.
- Aceitar solicitação.
- Recusar solicitação.
- Gerar contrato.
