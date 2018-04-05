CREATE VIEW public."Stages" AS
SELECT 
  "Events"."StageEnd"."Date",
  Count("Events"."StageStart"."Id") * 10 as "StartCount",
  Count("Events"."StageEnd"."Id") * 10 as "EndCount",
  Sum("Parameters"."StageEnd"."Income") * 10  AS "Income",
  Sum(public."CurrencyRate"."CurrencyRate" * "Income") as "Revenue"
FROM 
  "Events"."StageStart",
  "Events"."StageEnd",
  "Parameters"."StageEnd",
  public."CurrencyRate"
WHERE 
  "Events"."StageEnd"."ParametersId" = "Parameters"."StageEnd"."Id" AND
  "Events"."StageEnd"."Date" = public."CurrencyRate"."Date"
GROUP BY
  "Events"."StageEnd"."Date";
