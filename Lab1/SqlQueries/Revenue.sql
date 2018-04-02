select "Date", Sum("CurrencyPurchaseParameters"."Price")
from "Events" 
where "CurrencyPurchaseParameters"."Id" = "Events"."Id" && "EventId" = "1"
group by "Date"