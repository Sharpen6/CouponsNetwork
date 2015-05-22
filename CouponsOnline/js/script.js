var menuBar = ["home", "ManageCoupons", "ActiveCoupons", "Purchased", "CreateCoupon", "AddBusiness", "AddCategory", "AddInterest"];
var lastDiv;

function SwitchTo(divName) {
    if (divName == 'prevDiv')
        divName = lastDiv;
    else
        lastDiv = divName;
    for (var i = 0; i < menuBar.length; i++) {
        var e = document.getElementById(menuBar[i]);
        if (e!=null)
            if (divName == menuBar[i]) {
                e.style.display = 'block';
            }
            else {
                e.style.display = 'none';
            }
    }
}