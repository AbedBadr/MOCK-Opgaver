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
    
}