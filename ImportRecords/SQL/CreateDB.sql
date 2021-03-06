--
-- PostgreSQL database dump
--

-- Dumped from database version 10.3
-- Dumped by pg_dump version 10.3

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: events; Type: SCHEMA; Schema: -; Owner: -
--

CREATE SCHEMA events;


--
-- Name: parameters; Type: SCHEMA; Schema: -; Owner: -
--

CREATE SCHEMA parameters;


--
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: -
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: -
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET default_tablespace = '';

SET default_with_oids = false;

--
-- Name: currency_purchase; Type: TABLE; Schema: events; Owner: -
--

CREATE TABLE events.currency_purchase (
    id integer NOT NULL,
    date timestamp without time zone NOT NULL,
    parameters_id integer NOT NULL,
    udid text
);


--
-- Name: currency_purchase_id_seq; Type: SEQUENCE; Schema: events; Owner: -
--

CREATE SEQUENCE events.currency_purchase_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: currency_purchase_id_seq; Type: SEQUENCE OWNED BY; Schema: events; Owner: -
--

ALTER SEQUENCE events.currency_purchase_id_seq OWNED BY events.currency_purchase.id;


--
-- Name: first_launch; Type: TABLE; Schema: events; Owner: -
--

CREATE TABLE events.first_launch (
    id integer NOT NULL,
    date timestamp without time zone NOT NULL,
    parameters_id integer NOT NULL,
    udid text
);


--
-- Name: first_launch_id_seq; Type: SEQUENCE; Schema: events; Owner: -
--

CREATE SEQUENCE events.first_launch_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: first_launch_id_seq; Type: SEQUENCE OWNED BY; Schema: events; Owner: -
--

ALTER SEQUENCE events.first_launch_id_seq OWNED BY events.first_launch.id;


--
-- Name: game_launch; Type: TABLE; Schema: events; Owner: -
--

CREATE TABLE events.game_launch (
    id integer NOT NULL,
    date timestamp without time zone NOT NULL,
    udid text
);


--
-- Name: game_launch_id_seq; Type: SEQUENCE; Schema: events; Owner: -
--

CREATE SEQUENCE events.game_launch_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: game_launch_id_seq; Type: SEQUENCE OWNED BY; Schema: events; Owner: -
--

ALTER SEQUENCE events.game_launch_id_seq OWNED BY events.game_launch.id;


--
-- Name: in_game_purchase; Type: TABLE; Schema: events; Owner: -
--

CREATE TABLE events.in_game_purchase (
    id integer NOT NULL,
    date timestamp without time zone NOT NULL,
    parameters_id integer NOT NULL,
    udid text
);


--
-- Name: in_game_purchase_id_seq; Type: SEQUENCE; Schema: events; Owner: -
--

CREATE SEQUENCE events.in_game_purchase_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: in_game_purchase_id_seq; Type: SEQUENCE OWNED BY; Schema: events; Owner: -
--

ALTER SEQUENCE events.in_game_purchase_id_seq OWNED BY events.in_game_purchase.id;


--
-- Name: stage_end; Type: TABLE; Schema: events; Owner: -
--

CREATE TABLE events.stage_end (
    id integer NOT NULL,
    date timestamp without time zone NOT NULL,
    parameters_id integer NOT NULL,
    udid text
);


--
-- Name: stage_end_id_seq; Type: SEQUENCE; Schema: events; Owner: -
--

CREATE SEQUENCE events.stage_end_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: stage_end_id_seq; Type: SEQUENCE OWNED BY; Schema: events; Owner: -
--

ALTER SEQUENCE events.stage_end_id_seq OWNED BY events.stage_end.id;


--
-- Name: stage_start; Type: TABLE; Schema: events; Owner: -
--

CREATE TABLE events.stage_start (
    id integer NOT NULL,
    date timestamp without time zone NOT NULL,
    parameters_id integer NOT NULL,
    udid text
);


--
-- Name: stage_start_id_seq; Type: SEQUENCE; Schema: events; Owner: -
--

CREATE SEQUENCE events.stage_start_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: stage_start_id_seq; Type: SEQUENCE OWNED BY; Schema: events; Owner: -
--

ALTER SEQUENCE events.stage_start_id_seq OWNED BY events.stage_start.id;


--
-- Name: currency_purchase; Type: TABLE; Schema: parameters; Owner: -
--

CREATE TABLE parameters.currency_purchase (
    id integer NOT NULL,
    income integer NOT NULL,
    name text,
    price numeric NOT NULL
);


--
-- Name: currency_purchase_id_seq; Type: SEQUENCE; Schema: parameters; Owner: -
--

CREATE SEQUENCE parameters.currency_purchase_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: currency_purchase_id_seq; Type: SEQUENCE OWNED BY; Schema: parameters; Owner: -
--

ALTER SEQUENCE parameters.currency_purchase_id_seq OWNED BY parameters.currency_purchase.id;


--
-- Name: first_launch; Type: TABLE; Schema: parameters; Owner: -
--

CREATE TABLE parameters.first_launch (
    id integer NOT NULL,
    age integer NOT NULL,
    country text,
    gender text
);


--
-- Name: first_launch_id_seq; Type: SEQUENCE; Schema: parameters; Owner: -
--

CREATE SEQUENCE parameters.first_launch_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: first_launch_id_seq; Type: SEQUENCE OWNED BY; Schema: parameters; Owner: -
--

ALTER SEQUENCE parameters.first_launch_id_seq OWNED BY parameters.first_launch.id;


--
-- Name: in_game_purchase; Type: TABLE; Schema: parameters; Owner: -
--

CREATE TABLE parameters.in_game_purchase (
    id integer NOT NULL,
    item text,
    price integer NOT NULL
);


--
-- Name: in_game_purchase_id_seq; Type: SEQUENCE; Schema: parameters; Owner: -
--

CREATE SEQUENCE parameters.in_game_purchase_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: in_game_purchase_id_seq; Type: SEQUENCE OWNED BY; Schema: parameters; Owner: -
--

ALTER SEQUENCE parameters.in_game_purchase_id_seq OWNED BY parameters.in_game_purchase.id;


--
-- Name: stage_end; Type: TABLE; Schema: parameters; Owner: -
--

CREATE TABLE parameters.stage_end (
    id integer NOT NULL,
    income integer,
    stage integer NOT NULL,
    "time" integer NOT NULL,
    win boolean NOT NULL
);


--
-- Name: stage_end_id_seq; Type: SEQUENCE; Schema: parameters; Owner: -
--

CREATE SEQUENCE parameters.stage_end_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: stage_end_id_seq; Type: SEQUENCE OWNED BY; Schema: parameters; Owner: -
--

ALTER SEQUENCE parameters.stage_end_id_seq OWNED BY parameters.stage_end.id;


--
-- Name: stage_start; Type: TABLE; Schema: parameters; Owner: -
--

CREATE TABLE parameters.stage_start (
    id integer NOT NULL,
    stage integer NOT NULL
);


--
-- Name: stage_start_id_seq; Type: SEQUENCE; Schema: parameters; Owner: -
--

CREATE SEQUENCE parameters.stage_start_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: stage_start_id_seq; Type: SEQUENCE OWNED BY; Schema: parameters; Owner: -
--

ALTER SEQUENCE parameters.stage_start_id_seq OWNED BY parameters.stage_start.id;


--
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


--
-- Name: currency_purchase id; Type: DEFAULT; Schema: events; Owner: -
--

ALTER TABLE ONLY events.currency_purchase ALTER COLUMN id SET DEFAULT nextval('events.currency_purchase_id_seq'::regclass);


--
-- Name: first_launch id; Type: DEFAULT; Schema: events; Owner: -
--

ALTER TABLE ONLY events.first_launch ALTER COLUMN id SET DEFAULT nextval('events.first_launch_id_seq'::regclass);


--
-- Name: game_launch id; Type: DEFAULT; Schema: events; Owner: -
--

ALTER TABLE ONLY events.game_launch ALTER COLUMN id SET DEFAULT nextval('events.game_launch_id_seq'::regclass);


--
-- Name: in_game_purchase id; Type: DEFAULT; Schema: events; Owner: -
--

ALTER TABLE ONLY events.in_game_purchase ALTER COLUMN id SET DEFAULT nextval('events.in_game_purchase_id_seq'::regclass);


--
-- Name: stage_end id; Type: DEFAULT; Schema: events; Owner: -
--

ALTER TABLE ONLY events.stage_end ALTER COLUMN id SET DEFAULT nextval('events.stage_end_id_seq'::regclass);


--
-- Name: stage_start id; Type: DEFAULT; Schema: events; Owner: -
--

ALTER TABLE ONLY events.stage_start ALTER COLUMN id SET DEFAULT nextval('events.stage_start_id_seq'::regclass);


--
-- Name: currency_purchase id; Type: DEFAULT; Schema: parameters; Owner: -
--

ALTER TABLE ONLY parameters.currency_purchase ALTER COLUMN id SET DEFAULT nextval('parameters.currency_purchase_id_seq'::regclass);


--
-- Name: first_launch id; Type: DEFAULT; Schema: parameters; Owner: -
--

ALTER TABLE ONLY parameters.first_launch ALTER COLUMN id SET DEFAULT nextval('parameters.first_launch_id_seq'::regclass);


--
-- Name: in_game_purchase id; Type: DEFAULT; Schema: parameters; Owner: -
--

ALTER TABLE ONLY parameters.in_game_purchase ALTER COLUMN id SET DEFAULT nextval('parameters.in_game_purchase_id_seq'::regclass);


--
-- Name: stage_end id; Type: DEFAULT; Schema: parameters; Owner: -
--

ALTER TABLE ONLY parameters.stage_end ALTER COLUMN id SET DEFAULT nextval('parameters.stage_end_id_seq'::regclass);


--
-- Name: stage_start id; Type: DEFAULT; Schema: parameters; Owner: -
--

ALTER TABLE ONLY parameters.stage_start ALTER COLUMN id SET DEFAULT nextval('parameters.stage_start_id_seq'::regclass);


--
-- Name: currency_purchase pk_currency_purchase; Type: CONSTRAINT; Schema: events; Owner: -
--

ALTER TABLE ONLY events.currency_purchase
    ADD CONSTRAINT pk_currency_purchase PRIMARY KEY (id);


--
-- Name: first_launch pk_first_launch; Type: CONSTRAINT; Schema: events; Owner: -
--

ALTER TABLE ONLY events.first_launch
    ADD CONSTRAINT pk_first_launch PRIMARY KEY (id);


--
-- Name: game_launch pk_game_launch; Type: CONSTRAINT; Schema: events; Owner: -
--

ALTER TABLE ONLY events.game_launch
    ADD CONSTRAINT pk_game_launch PRIMARY KEY (id);


--
-- Name: in_game_purchase pk_in_game_purchase; Type: CONSTRAINT; Schema: events; Owner: -
--

ALTER TABLE ONLY events.in_game_purchase
    ADD CONSTRAINT pk_in_game_purchase PRIMARY KEY (id);


--
-- Name: stage_end pk_stage_end; Type: CONSTRAINT; Schema: events; Owner: -
--

ALTER TABLE ONLY events.stage_end
    ADD CONSTRAINT pk_stage_end PRIMARY KEY (id);


--
-- Name: stage_start pk_stage_start; Type: CONSTRAINT; Schema: events; Owner: -
--

ALTER TABLE ONLY events.stage_start
    ADD CONSTRAINT pk_stage_start PRIMARY KEY (id);


--
-- Name: currency_purchase pk_currency_purchase; Type: CONSTRAINT; Schema: parameters; Owner: -
--

ALTER TABLE ONLY parameters.currency_purchase
    ADD CONSTRAINT pk_currency_purchase PRIMARY KEY (id);


--
-- Name: first_launch pk_first_launch; Type: CONSTRAINT; Schema: parameters; Owner: -
--

ALTER TABLE ONLY parameters.first_launch
    ADD CONSTRAINT pk_first_launch PRIMARY KEY (id);


--
-- Name: in_game_purchase pk_in_game_purchase; Type: CONSTRAINT; Schema: parameters; Owner: -
--

ALTER TABLE ONLY parameters.in_game_purchase
    ADD CONSTRAINT pk_in_game_purchase PRIMARY KEY (id);


--
-- Name: stage_end pk_stage_end; Type: CONSTRAINT; Schema: parameters; Owner: -
--

ALTER TABLE ONLY parameters.stage_end
    ADD CONSTRAINT pk_stage_end PRIMARY KEY (id);


--
-- Name: stage_start pk_stage_start; Type: CONSTRAINT; Schema: parameters; Owner: -
--

ALTER TABLE ONLY parameters.stage_start
    ADD CONSTRAINT pk_stage_start PRIMARY KEY (id);


--
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- Name: IX_currency_purchase_parameters_id; Type: INDEX; Schema: events; Owner: -
--

CREATE UNIQUE INDEX "IX_currency_purchase_parameters_id" ON events.currency_purchase USING btree (parameters_id);


--
-- Name: IX_first_launch_parameters_id; Type: INDEX; Schema: events; Owner: -
--

CREATE UNIQUE INDEX "IX_first_launch_parameters_id" ON events.first_launch USING btree (parameters_id);


--
-- Name: IX_in_game_purchase_parameters_id; Type: INDEX; Schema: events; Owner: -
--

CREATE UNIQUE INDEX "IX_in_game_purchase_parameters_id" ON events.in_game_purchase USING btree (parameters_id);


--
-- Name: IX_stage_end_parameters_id; Type: INDEX; Schema: events; Owner: -
--

CREATE UNIQUE INDEX "IX_stage_end_parameters_id" ON events.stage_end USING btree (parameters_id);


--
-- Name: IX_stage_start_parameters_id; Type: INDEX; Schema: events; Owner: -
--

CREATE UNIQUE INDEX "IX_stage_start_parameters_id" ON events.stage_start USING btree (parameters_id);


--
-- Name: currency_purchase parameters_id; Type: FK CONSTRAINT; Schema: events; Owner: -
--

ALTER TABLE ONLY events.currency_purchase
    ADD CONSTRAINT parameters_id FOREIGN KEY (parameters_id) REFERENCES parameters.currency_purchase(id) ON DELETE CASCADE;


--
-- Name: first_launch parameters_id; Type: FK CONSTRAINT; Schema: events; Owner: -
--

ALTER TABLE ONLY events.first_launch
    ADD CONSTRAINT parameters_id FOREIGN KEY (parameters_id) REFERENCES parameters.first_launch(id) ON DELETE CASCADE;


--
-- Name: in_game_purchase parameters_id; Type: FK CONSTRAINT; Schema: events; Owner: -
--

ALTER TABLE ONLY events.in_game_purchase
    ADD CONSTRAINT parameters_id FOREIGN KEY (parameters_id) REFERENCES parameters.in_game_purchase(id) ON DELETE CASCADE;


--
-- Name: stage_end parameters_id; Type: FK CONSTRAINT; Schema: events; Owner: -
--

ALTER TABLE ONLY events.stage_end
    ADD CONSTRAINT parameters_id FOREIGN KEY (parameters_id) REFERENCES parameters.stage_end(id) ON DELETE CASCADE;


--
-- Name: stage_start parameters_id; Type: FK CONSTRAINT; Schema: events; Owner: -
--

ALTER TABLE ONLY events.stage_start
    ADD CONSTRAINT parameters_id FOREIGN KEY (parameters_id) REFERENCES parameters.stage_start(id) ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

