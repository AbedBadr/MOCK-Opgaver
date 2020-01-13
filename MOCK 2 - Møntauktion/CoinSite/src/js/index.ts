import axios, {
    AxiosResponse,
    AxiosError,
}
from "../../node_modules/axios/index";

let coinUri: string = "https://localhost:44358/api/Coins/";

interface ICoin {
    Id: number;
    Genstand: string;
    Bud: number;
    Navn: string;
}

function GetAllCoins(): void {
    let tablebody: HTMLTableElement = <HTMLTableElement>document.getElementById("tbody");
    tablebody.innerHTML = "";

    let outputElement: HTMLOutputElement = <HTMLOutputElement>document.getElementById("output");
    outputElement.innerHTML = "";

    axios.get<ICoin[]>(coinUri)
    .then((response: AxiosResponse<ICoin[]>) => {
        let data: ICoin[] = response.data;
        data.forEach(coin => {
            let row = tablebody.insertRow();
            row.insertCell(0).innerHTML = coin.Id+"";
            row.insertCell(-1).innerHTML = coin.Navn;
            row.insertCell(-1).innerHTML = coin.Bud+"";
            row.insertCell(-1).innerHTML = coin.Genstand;
        });
    })
    .catch((error: AxiosError) => {
        console.log(error);
        outputElement.innerHTML = error.message;
    });
}

function GetOneCoin(): void {
    let outputElement: HTMLOutputElement = <HTMLOutputElement>document.getElementById("output");
    outputElement.innerHTML = "";

    let inputElement: HTMLInputElement = <HTMLInputElement>document.getElementById("idInput");
    let coinId: string = inputElement.value;

    axios.get<ICoin>(coinUri + "/" + coinId)
    .then((response: AxiosResponse<ICoin>) => {
        let data: ICoin = response.data;

        outputElement.innerHTML = JSON.stringify(data);
    })
    .catch((error: AxiosError) => {
        console.log(error);
        outputElement.innerHTML = error.message;
    });
}

function PostCoin(): void {

}

let GetCoinsButton: HTMLButtonElement = <HTMLButtonElement>document.getElementById("GetCoinsButton");
GetCoinsButton.addEventListener("click", GetAllCoins);

let GetOneCoinButton: HTMLButtonElement = <HTMLButtonElement>document.getElementById("GetOneCoinButton");
GetOneCoinButton.addEventListener("click", GetOneCoin);

let PostCoinButton: HTMLButtonElement = <HTMLButtonElement>document.getElementById("");
PostCoinButton.addEventListener("click", PostCoin);

let PostCoinId: HTMLInputElement = <HTMLInputElement>document.getElementById("PostCoinId");

let PostCoinNavn: HTMLInputElement = <HTMLInputElement>document.getElementById("PostCoinNavn");

let PostCoinBud: HTMLInputElement = <HTMLInputElement>document.getElementById("PostCoinBud");

let PostCoinGenstand: HTMLInputElement = <HTMLInputElement>document.getElementById("PostCoinGenstand");
