CREATE VIEW public.dau AS
SELECT 
  date,
  Count(*) * 10 AS count
FROM 
  events.first_launch,
  parameters.first_launch
GROUP BY 
  date;

CREATE VIEW public.new_users AS
SELECT 
  date, 
  Count(fl.*) * 10 AS count
FROM 
  events.first_launch,
  (SELECT DISTINCT (udid) FROM events.first_launch) AS fl 
GROUP BY 
  date;

CREATE VIEW public.mau AS
SELECT 
  Count(DISTINCT udid) * 10 as count
FROM 
  events.first_launch;

CREATE VIEW public.revenue as 
SELECT 
  events.currency_purchase.date, 
  Sum(parameters.currency_purchase.price) * 10 as revenue
FROM 
  events.currency_purchase, 
  parameters.currency_purchase
WHERE 
  events.currency_purchase.parameters_id = parameters.currency_purchase.id
GROUP BY
  events.currency_purchase.date;

CREATE VIEW public.stages AS
SELECT 
  events.stage_end.date,
  Count(events.stage_start.id) * 10 as start_count,
  Count(events.stage_end.id) * 10 as end_count,
  Sum(parameters.stage_end.income) * 10  AS income,
  Sum(public.currency_rate.currency_rate * income) as revenue
FROM 
  events.stage_start,
  events.stage_end,
  parameters.stage_end,
  public.currency_rate
WHERE 
  events.stage_end.parameters_id = parameters.stage_end.id AND
  events.stage_end.date = public.currency_rate.date
GROUP BY
  events.stage_end.date;

CREATE VIEW public.items AS
SELECT 
  events.in_game_purchase.date,
  COUNT(*),
  SUM(parameters.in_game_purchase.price) * 10 AS total_price,
  SUM(parameters.in_game_purchase.price * public.currency_rate.currency_rate) * 10 AS dollar_price
FROM 
  parameters.in_game_purchase, 
  events.in_game_purchase,
  public.currency_rate
WHERE 
  events.in_game_purchase.parameters_id = parameters.in_game_purchase.id
GROUP BY 
  events.in_game_purchase.date;
