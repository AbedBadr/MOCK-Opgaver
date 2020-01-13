function calculate(): void {
    let carPriceInputElement: HTMLInputElement = <HTMLInputElement>document.getElementById("carPrice");
    
    let carPriceString: string = carPriceInputElement.value;

    var carPriceNumber = parseInt(carPriceString);

    let carTypeElement: HTMLSelectElement = <HTMLSelectElement>document.getElementById("carTypeSelect");
    let carType: string = carTypeElement.value;

    var result = calc(carType, carPriceNumber);
    console.log("Afgiften er " + result);

    let outputElement: HTMLOutputElement = <HTMLOutputElement>document.getElementById("resultSpan");
    outputElement.innerHTML = "Afgiften er " + result.toString();
}

function calc(carType: string, price: number): number{
    switch(carType) {
        case "Personbil":
            {
                if (price <= 200000){
                    let bilAfgift: number = price * 0.85;
                    return bilAfgift;
                }
                else
                {
                    let bilAfgift: number = (price * 1.50) - 130000;
                    return bilAfgift;
                }
            }
        case "Elbil":
            {
                if (price <= 200000){
                    let elBilAfgift: number = (price * 0.85) * 0.20;
                    return elBilAfgift;
                }
                else{
                    let elBilAfgift: number = ((price * 1.50) - 130000) * 0.20;
                    return elBilAfgift;
                }
            }
        default:
            return -1;
    }
}

let sumButton: HTMLButtonElement = <HTMLButtonElement>document.getElementById("calculateFee");
sumButton.addEventListener("click", calculate);