PGDMP         .                 z            PDPS    14.1    14.1                0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            	           1262    24628    PDPS    DATABASE     c   CREATE DATABASE "PDPS" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Turkish_Turkey.1254';
    DROP DATABASE "PDPS";
                postgres    false            ?            1259    24630    tblmaid    TABLE     9  CREATE TABLE public.tblmaid (
    maid_id integer NOT NULL,
    name character varying(255) NOT NULL,
    surname character varying(255) NOT NULL,
    ratingavg numeric DEFAULT '-1'::integer,
    roomscleaned integer DEFAULT 0 NOT NULL,
    isactive boolean DEFAULT true,
    salary numeric DEFAULT 0 NOT NULL
);
    DROP TABLE public.tblmaid;
       public         heap    postgres    false            ?            1259    24639    tblmaid_maid_id_seq    SEQUENCE     ?   CREATE SEQUENCE public.tblmaid_maid_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE public.tblmaid_maid_id_seq;
       public          postgres    false    209            
           0    0    tblmaid_maid_id_seq    SEQUENCE OWNED BY     K   ALTER SEQUENCE public.tblmaid_maid_id_seq OWNED BY public.tblmaid.maid_id;
          public          postgres    false    210            ?            1259    24640    tbltemizlikkayit    TABLE     ?   CREATE TABLE public.tbltemizlikkayit (
    temizlik_id integer NOT NULL,
    maid_id integer NOT NULL,
    odatipi bit(1) NOT NULL,
    date date NOT NULL,
    odano integer NOT NULL,
    rate numeric NOT NULL,
    yorum character varying
);
 $   DROP TABLE public.tbltemizlikkayit;
       public         heap    postgres    false            ?            1259    24645     tbltemizlikkayit_temizlik_id_seq    SEQUENCE     ?   CREATE SEQUENCE public.tbltemizlikkayit_temizlik_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 7   DROP SEQUENCE public.tbltemizlikkayit_temizlik_id_seq;
       public          postgres    false    211                       0    0     tbltemizlikkayit_temizlik_id_seq    SEQUENCE OWNED BY     e   ALTER SEQUENCE public.tbltemizlikkayit_temizlik_id_seq OWNED BY public.tbltemizlikkayit.temizlik_id;
          public          postgres    false    212            ?            1259    24657    tbluser    TABLE     ?   CREATE TABLE public.tbluser (
    username character varying NOT NULL,
    password character varying NOT NULL,
    name character varying NOT NULL,
    surname character varying NOT NULL,
    user_id integer NOT NULL
);
    DROP TABLE public.tbluser;
       public         heap    postgres    false            ?            1259    24666    tbluser_user_id_seq    SEQUENCE     ?   ALTER TABLE public.tbluser ALTER COLUMN user_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.tbluser_user_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    213            j           2604    24646    tblmaid maid_id    DEFAULT     r   ALTER TABLE ONLY public.tblmaid ALTER COLUMN maid_id SET DEFAULT nextval('public.tblmaid_maid_id_seq'::regclass);
 >   ALTER TABLE public.tblmaid ALTER COLUMN maid_id DROP DEFAULT;
       public          postgres    false    210    209            k           2604    24647    tbltemizlikkayit temizlik_id    DEFAULT     ?   ALTER TABLE ONLY public.tbltemizlikkayit ALTER COLUMN temizlik_id SET DEFAULT nextval('public.tbltemizlikkayit_temizlik_id_seq'::regclass);
 K   ALTER TABLE public.tbltemizlikkayit ALTER COLUMN temizlik_id DROP DEFAULT;
       public          postgres    false    212    211            ?          0    24630    tblmaid 
   TABLE DATA           d   COPY public.tblmaid (maid_id, name, surname, ratingavg, roomscleaned, isactive, salary) FROM stdin;
    public          postgres    false    209   ?                  0    24640    tbltemizlikkayit 
   TABLE DATA           c   COPY public.tbltemizlikkayit (temizlik_id, maid_id, odatipi, date, odano, rate, yorum) FROM stdin;
    public          postgres    false    211   @                 0    24657    tbluser 
   TABLE DATA           M   COPY public.tbluser (username, password, name, surname, user_id) FROM stdin;
    public          postgres    false    213   ?                  0    0    tblmaid_maid_id_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public.tblmaid_maid_id_seq', 33, true);
          public          postgres    false    210                       0    0     tbltemizlikkayit_temizlik_id_seq    SEQUENCE SET     O   SELECT pg_catalog.setval('public.tbltemizlikkayit_temizlik_id_seq', 25, true);
          public          postgres    false    212                       0    0    tbluser_user_id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public.tbluser_user_id_seq', 4, true);
          public          postgres    false    214            m           2606    24649    tblmaid tblmaid_pkey 
   CONSTRAINT     W   ALTER TABLE ONLY public.tblmaid
    ADD CONSTRAINT tblmaid_pkey PRIMARY KEY (maid_id);
 >   ALTER TABLE ONLY public.tblmaid DROP CONSTRAINT tblmaid_pkey;
       public            postgres    false    209            o           2606    24651 &   tbltemizlikkayit tbltemizlikkayit_pkey 
   CONSTRAINT     m   ALTER TABLE ONLY public.tbltemizlikkayit
    ADD CONSTRAINT tbltemizlikkayit_pkey PRIMARY KEY (temizlik_id);
 P   ALTER TABLE ONLY public.tbltemizlikkayit DROP CONSTRAINT tbltemizlikkayit_pkey;
       public            postgres    false    211            q           2606    24665    tbluser tbluser_pkey 
   CONSTRAINT     W   ALTER TABLE ONLY public.tbluser
    ADD CONSTRAINT tbluser_pkey PRIMARY KEY (user_id);
 >   ALTER TABLE ONLY public.tbluser DROP CONSTRAINT tbluser_pkey;
       public            postgres    false    213            r           2606    24652    tbltemizlikkayit fk_maid_id    FK CONSTRAINT     ?   ALTER TABLE ONLY public.tbltemizlikkayit
    ADD CONSTRAINT fk_maid_id FOREIGN KEY (maid_id) REFERENCES public.tblmaid(maid_id) ON DELETE CASCADE;
 E   ALTER TABLE ONLY public.tbltemizlikkayit DROP CONSTRAINT fk_maid_id;
       public          postgres    false    211    3181    209            ?   ~   x?U?[
?@E?o???$??^?	
??)R?U?Ѕ??[!ɅsB?gx????mDO??Xk???????>?ӇB1??XD;?X[??B?S*???????
?????Ј??ߑ?QD?_0?          b   x?M?1? D?z?.?e ?Kx),l??ӻ?H????,=8?FI?t??P!??-!h6[??N??Ի?Ҽճ?c???-|_?+?~q?eB??JD?$5?         7   x??HN??442?ѩE????qs?$g䃅Ks29??O????4?????? ???     