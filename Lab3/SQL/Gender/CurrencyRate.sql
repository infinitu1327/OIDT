CREATE TABLE public.currency_rate AS
SELECT 
  events.currency_purchase.date, 
  Sum(price) / Sum(income) as currency_rate
FROM 
  events.currency_purchase, 
  parameters.currency_purchase,
  parameters.first_launch
WHERE 
  parameters_id = parameters.currency_purchase.id
GROUP BY
  events.currency_purchase.date,
  parameters.first_launch.gender
ORDER BY
  date,
  parameters.first_launch.gender;