function generateSchedule() {
    const P = parseFloat(document.getElementById("amount").value);
    const annualRate = parseFloat(document.getElementById("rate").value);
    const n = parseInt(document.getElementById("months").value);
    const tableBody = document.getElementById("scheduleBody");
    const loanTable = document.getElementById("loanTable");


    if (isNaN(P) || isNaN(annualRate) || isNaN(n) || P <= 0 || n <= 0) {
        alert("Please enter valid positive numbers");
        return;
    }

    const r = (annualRate / 12) / 100;
    const top = Math.pow(1 + r, n);
    const bottom = top - 1;
    const emi = P * r * (top / bottom);

    tableBody.innerHTML = "";
    loanTable.style.display = "table";

    document.body.style.alignItems = "flex-start";
    document.body.style.paddingTop = "50px";

    let currentBalance = P;

    for (let i = 1; i <= n; i++) {
        let interest = currentBalance * r;
        let principal = emi - interest;
        let remainingBalance = currentBalance - principal;

        if (i === n || remainingBalance < 0) remainingBalance = 0;

        let row = `<tr>
            <td>${i}</td>
            <td>${currentBalance.toFixed(2)}</td>
            <td>${emi.toFixed(2)}</td>
            <td>${principal.toFixed(2)}</td>
            <td>${interest.toFixed(2)}</td>
            <td>${remainingBalance.toFixed(2)}</td>
        </tr>`;

        tableBody.innerHTML += row;
        currentBalance = remainingBalance;
    }
}