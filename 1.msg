Delivered-To: nichidaithailand@gmail.com
Received: by 10.74.129.65 with SMTP id p1csp364633oog;
        Wed, 21 Feb 2018 00:57:43 -0800 (PST)
X-Received: by 10.36.23.3 with SMTP id 3mr2485907ith.60.1519203463239;
        Wed, 21 Feb 2018 00:57:43 -0800 (PST)
ARC-Seal: i=1; a=rsa-sha256; t=1519203463; cv=none;
        d=google.com; s=arc-20160816;
        b=zgPOczf/s2uvp0pQwOr3CAQpdWTLvG/qrf7KPPvHziIbzHyko0FTiDBg173qwv5SJD
         Jg5iSipwrdxOSDOuLfvzmmPu0JxOkoRjbj61+rTXmmEZiEBrY2Ran4w8I1/wrwYehqmL
         EhP01b5o9OQqjTby3/HmNBLkMFKeJV1cDVL7WvHnOcrQlNipif62ddOur8T8g4hB5K9M
         7cDF6HlUQ2n5DkIvYs26X4ZBUfcX3400kPDIGx4Qw0FgPPxNDauNJfhcCMFeVKTqKayE
         5OhSSSdSFleYHDOS1NyU/3o8dOTTibyiWJebmBQVsbl+Y47wXzQ80HSnIe5J6wt1uEKG
         ag0g==
ARC-Message-Signature: i=1; a=rsa-sha256; c=relaxed/relaxed; d=google.com; s=arc-20160816;
        h=date:message-id:in-reply-to:references:subject:auto-submitted:to
         :from:dkim-signature:arc-authentication-results;
        bh=6XC9+PeG4Lbd8uRA/ZWMchT7lbAuwePFtMNU7lA4klc=;
        b=hmGS+/OzjWcJnGBGKRq5Lue4I1QQJ5cjQZsV1xL24nOqK/J+RCfQnn5+c8x+Wq0lfY
         iXehEDXd/G9hMZY/eIixPflTcs4lkqmnFV83awp2RLkZd6+DEt7pngAqduFXAkenAlcs
         XmpaVstw5I17WBd79azmTDkP24v1W2XHInolU0zUIhLf3u0h7+kr35+iCr5f5JeyQ3Ym
         fVAPFlcw89D546DfMTowWh4mdH3W03OFdqykgiQHmLunPZ+L0kebcBKnFG+hKaf2mcfq
         K5Cg5JxYdg7GouaEk186TIHriiuAMkmnW2EKEs1cSM5wAOvXC0wM4Q2Fe2UG7/tMr6WU
         MokA==
ARC-Authentication-Results: i=1; mx.google.com;
       dkim=pass header.i=@google.com header.s=20161025 header.b=bLMGFlGD;
       spf=pass (google.com: best guess record for domain of postmaster@mail-sor-f69.google.com designates 209.85.220.69 as permitted sender) smtp.helo=mail-sor-f69.google.com;
       dmarc=pass (p=REJECT sp=REJECT dis=NONE) header.from=google.com
Return-Path: <>
Received: from mail-sor-f69.google.com (mail-sor-f69.google.com. [209.85.220.69])
        by mx.google.com with SMTPS id 139sor15574768itl.56.2018.02.21.00.57.42
        for <nichidaithailand@gmail.com>
        (Google Transport Security);
        Wed, 21 Feb 2018 00:57:43 -0800 (PST)
Received-SPF: pass (google.com: best guess record for domain of postmaster@mail-sor-f69.google.com designates 209.85.220.69 as permitted sender) client-ip=209.85.220.69;
Authentication-Results: mx.google.com;
       dkim=pass header.i=@google.com header.s=20161025 header.b=bLMGFlGD;
       spf=pass (google.com: best guess record for domain of postmaster@mail-sor-f69.google.com designates 209.85.220.69 as permitted sender) smtp.helo=mail-sor-f69.google.com;
       dmarc=pass (p=REJECT sp=REJECT dis=NONE) header.from=google.com
DKIM-Signature: v=1; a=rsa-sha256; c=relaxed/relaxed;
        d=google.com; s=20161025;
        h=from:to:auto-submitted:subject:references:in-reply-to:message-id
         :date;
        bh=6XC9+PeG4Lbd8uRA/ZWMchT7lbAuwePFtMNU7lA4klc=;
        b=bLMGFlGDoL06cKonA41vNediK87FF3J9FBFSBz8Rpu4UH9FfUgDGnbx4wktv7nIf71
         Inb4G5+uVhE94Pbehbo9UtaQdanbSOn67u5r2SSefgNk6YL1d8fpLF80TgmhOnJUGbVx
         GDHIg0y8Ds47RR+gokQtRvu0tMsdbgo2sjmzUmQHmJKkMWZS+f2JeGIk/A0i+vzGNDbJ
         Cm/D5/iVWSAMqtCpiaDIzQjsQmde3mY7CfPvvW0umwKR9hseQuthrgNqf+8XYafqaheP
         4sBGcwNUNb0/ZxOekGu46zE7yjxqc0qtvpGLOXm8JAeG+HNQm8e7gtKcZnqxDMsgpOyV
         tdOQ==
X-Google-DKIM-Signature: v=1; a=rsa-sha256; c=relaxed/relaxed;
        d=1e100.net; s=20161025;
        h=x-gm-message-state:from:to:auto-submitted:subject:references
         :in-reply-to:message-id:date;
        bh=6XC9+PeG4Lbd8uRA/ZWMchT7lbAuwePFtMNU7lA4klc=;
        b=cIYX5Ydhxe04cimA+wUUDHueZVRoLcVEaMgYRgvUdBVInoHY4/rTKpqUd49Ujh6Y2f
         orAejBvLBdxR6QI05/5Vo77lkLcLr/Pi9FkyST9bAN/DedQlcNdAiusoK8HBqYm6YJjF
         y5LKwlxfRNo/EA8HfYbMTCWzoxU8o8ZqfwfQvME0P2C/aIDWGOFnt9usdD01DMDiWtec
         DG8qir65byCviL/yHdTRWM6/RDi18tzJkGFAcRQQ1fICPRemKZaOq7hgSgsWDqektGy8
         LHJ3hkdxcJdnH17NQAdFpMzf72xntfVDgWNujXQeCgc2WIVzlYoleB2svuJnqGPg3GmW
         2/8g==
X-Gm-Message-State: APf1xPCnOSBqT6mshdSD8IiPP0Sp1hqnGvK+hLWLr8C6qEMweHen8Iy+
	uGG2YqW6lHegqlgk
X-Received: by 10.36.88.201 with SMTP id f192mr1362141itb.4.1519203462893;
        Wed, 21 Feb 2018 00:57:42 -0800 (PST)
Received: by 10.36.37.12 with SMTP id g12am106278itg.0
         Wed, 21 Feb 2018 00:57:42 -0800 (PST)
X-Google-Smtp-Source: AH8x224JDDW8811QWcrfCTk3cL81Pgj9MimwBeOsQ5S1QW1Ag94iBzxB9N4JjpNha/W0ytakaD4/+aclTrLwJhZhPAnXkcoH28wZY+k=
X-Received: by 10.36.1.209 with SMTP id 200mr1393558itk.50.1519203462870;
        Wed, 21 Feb 2018 00:57:42 -0800 (PST)
Content-Type: multipart/report; boundary="001a1143d0a4beea0a0565b51e52"; report-type=delivery-status
Return-Path: <>
Received: by 10.36.1.209 with SMTP id 200mr1933465itk.50; Wed, 21 Feb 2018
 00:57:42 -0800 (PST)
From: Mail Delivery Subsystem <mailer-daemon@google.com>
To: 3hjSNWhAJAP0snhmnifnymfnqfsilrfnq.htr@trix.bounces.google.com
Auto-Submitted: auto-replied
Subject: Delivery Status Notification (Failure)
References: <001a1143d0a4bbdd730565b51e2f@google.com>
In-Reply-To: <001a1143d0a4bbdd730565b51e2f@google.com>
X-Failed-Recipients: phornthip@nichidai.co.thNopparat
Message-ID: <5a8d3486.d101240a.88bda.53b7.GMRIR@mx.google.com>
Date: Wed, 21 Feb 2018 00:57:42 -0800 (PST)

--001a1143d0a4beea0a0565b51e52
Content-Type: multipart/related; boundary="001a1143d0a4bef0320565b51e53"

--001a1143d0a4bef0320565b51e53
Content-Type: multipart/alternative; boundary="001a1143d0a4bef0410565b51e54"

--001a1143d0a4bef0410565b51e54
Content-Type: text/plain; charset="UTF-8"
Content-Transfer-Encoding: base64

CioqIOC5hOC4oeC5iOC4nuC4muC4l+C4teC5iOC4reC4ouC4ueC5iCAqKgoK4LmE4Lih4LmI4Liq
4Liy4Lih4Liy4Lij4LiW4Liq4LmI4LiH4LiC4LmJ4Lit4LiE4Lin4Liy4Lih4LiC4Lit4LiH4LiE
4Li44LiT4LmE4Lib4Lii4Lix4LiHIHBob3JudGhpcEBuaWNoaWRhaS5jby50aE5vcHBhcmF0IOC5
gOC4meC4t+C5iOC4reC4h+C4iOC4suC4geC5hOC4oeC5iOC4nuC4muC5guC4lOC5gOC4oeC4mSBu
aWNoaWRhaS5jby50aE5vcHBhcmF0IOC5guC4m+C4o+C4lOC4leC4o+C4p+C4iOC4quC4reC4muC4
geC4suC4o+C4quC4sOC4geC4lOC4nOC4tOC4lOC4q+C4o+C4t+C4reC4geC4suC4o+C5gOC4p+C5
ieC4meC4p+C4o+C4o+C4hOC4l+C4teC5iOC5hOC4oeC5iOC4iOC4s+C5gOC4m+C5h+C4meC5geC4
peC5ieC4p+C4peC4reC4h+C4reC4teC4geC4hOC4o+C4seC5ieC4hwoKCgrguITguLPguJXguK3g
uJrguITguLfguK06CgpETlMgRXJyb3I6IDExMjAxMzUgRE5TIHR5cGUgJ214JyBsb29rdXAgb2Yg
bmljaGlkYWkuY28udGhub3BwYXJhdCByZXNwb25kZWQgd2l0aCBjb2RlIE5YRE9NQUlODQpEb21h
aW4gbmFtZSBub3QgZm91bmQ6IG5pY2hpZGFpLmNvLnRobm9wcGFyYXQK
--001a1143d0a4bef0410565b51e54
Content-Type: text/html; charset="UTF-8"
Content-Transfer-Encoding: base64

CjxodG1sPgo8aGVhZD4KPHN0eWxlPgoqIHsKZm9udC1mYW1pbHk6Um9ib3RvLCAiSGVsdmV0aWNh
IE5ldWUiLCBIZWx2ZXRpY2EsIEFyaWFsLCBzYW5zLXNlcmlmOwp9Cjwvc3R5bGU+CjwvaGVhZD4K
PGJvZHk+Cjx0YWJsZSBjZWxscGFkZGluZz0iMCIgY2VsbHNwYWNpbmc9IjAiIGNsYXNzPSJlbWFp
bC13cmFwcGVyIiBzdHlsZT0icGFkZGluZy10b3A6MzJweDtiYWNrZ3JvdW5kLWNvbG9yOiNmZmZm
ZmY7Ij48dGJvZHk+Cjx0cj48dGQ+Cjx0YWJsZSBjZWxscGFkZGluZz0wIGNlbGxzcGFjaW5nPTA+
PHRib2R5Pgo8dHI+PHRkIHN0eWxlPSJtYXgtd2lkdGg6NTYwcHg7cGFkZGluZzoyNHB4IDI0cHgg
MzJweDtiYWNrZ3JvdW5kLWNvbG9yOiNmYWZhZmE7Ym9yZGVyOjFweCBzb2xpZCAjZTBlMGUwO2Jv
cmRlci1yYWRpdXM6MnB4Ij4KPGltZyBzdHlsZT0icGFkZGluZzowIDI0cHggMTZweCAwO2Zsb2F0
OmxlZnQiIHdpZHRoPTcyIGhlaWdodD03MiBhbHQ9IuC5hOC4reC4hOC4reC4meC4guC5ieC4reC4
nOC4tOC4lOC4nuC4peC4suC4lCIgc3JjPSJjaWQ6aWNvbi5wbmciPgo8dGFibGUgc3R5bGU9Im1p
bi13aWR0aDoyNzJweDtwYWRkaW5nLXRvcDo4cHgiPjx0Ym9keT4KPHRyPjx0ZD48aDIgc3R5bGU9
ImZvbnQtc2l6ZToyMHB4O2NvbG9yOiMyMTIxMjE7Zm9udC13ZWlnaHQ6Ym9sZDttYXJnaW46MCI+
CuC5hOC4oeC5iOC4nuC4muC4l+C4teC5iOC4reC4ouC4ueC5iAo8L2gyPjwvdGQ+PC90cj4KPHRy
Pjx0ZCBzdHlsZT0icGFkZGluZy10b3A6MjBweDtjb2xvcjojNzU3NTc1O2ZvbnQtc2l6ZToxNnB4
O2ZvbnQtd2VpZ2h0Om5vcm1hbDt0ZXh0LWFsaWduOmxlZnQiPgrguYTguKHguYjguKrguLLguKHg
uLLguKPguJbguKrguYjguIfguILguYnguK3guITguKfguLLguKHguILguK3guIfguITguLjguJPg
uYTguJvguKLguLHguIcgPGEgc3R5bGU9J2NvbG9yOiMyMTIxMjE7dGV4dC1kZWNvcmF0aW9uOm5v
bmUnPjxiPnBob3JudGhpcEBuaWNoaWRhaS5jby50aE5vcHBhcmF0PC9iPjwvYT4g4LmA4LiZ4Li3
4LmI4Lit4LiH4LiI4Liy4LiB4LmE4Lih4LmI4Lie4Lia4LmC4LiU4LmA4Lih4LiZIG5pY2hpZGFp
LmNvLnRoTm9wcGFyYXQg4LmC4Lib4Lij4LiU4LiV4Lij4Lin4LiI4Liq4Lit4Lia4LiB4Liy4Lij
4Liq4Liw4LiB4LiU4Lic4Li04LiU4Lir4Lij4Li34Lit4LiB4Liy4Lij4LmA4Lin4LmJ4LiZ4Lin
4Lij4Lij4LiE4LiX4Li14LmI4LmE4Lih4LmI4LiI4Liz4LmA4Lib4LmH4LiZ4LmB4Lil4LmJ4Lin
4Lil4Lit4LiH4Lit4Li14LiB4LiE4Lij4Lix4LmJ4LiHCjwvdGQ+PC90cj4KPC90Ym9keT48L3Rh
YmxlPgo8L3RkPjwvdHI+CjwvdGJvZHk+PC90YWJsZT4KPC90ZD48L3RyPgo8dHIgc3R5bGU9ImJv
cmRlcjpub25lO2JhY2tncm91bmQtY29sb3I6I2ZmZjtmb250LXNpemU6MTIuOHB4O3dpZHRoOjkw
JSI+Cjx0ZCBhbGlnbj0ibGVmdCIgc3R5bGU9InBhZGRpbmc6NDhweCAxMHB4Ij4K4LiE4Liz4LiV
4Lit4Lia4LiE4Li34LitOjxici8+CjxwIHN0eWxlPSJmb250LWZhbWlseTptb25vc3BhY2UiPgpE
TlMgRXJyb3I6IDExMjAxMzUgRE5TIHR5cGUgJiMzOTtteCYjMzk7IGxvb2t1cCBvZiBuaWNoaWRh
aS5jby50aG5vcHBhcmF0IHJlc3BvbmRlZCB3aXRoIGNvZGUgTlhET01BSU4KRG9tYWluIG5hbWUg
bm90IGZvdW5kOiBuaWNoaWRhaS5jby50aG5vcHBhcmF0CjwvcD4KPC90ZD4KPC90cj4KPC90Ym9k
eT48L3RhYmxlPgo8L2JvZHk+CjwvaHRtbD4K
--001a1143d0a4bef0410565b51e54--
--001a1143d0a4bef0320565b51e53
Content-Type: image/png; name="icon.png"
Content-Disposition: attachment; filename="icon.png"
Content-Transfer-Encoding: base64
Content-ID: <icon.png>

iVBORw0KGgoAAAANSUhEUgAAAJAAAACQCAYAAADnRuK4AAAACXBIWXMAABYlAAAWJQFJUiTwAAAA
GXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAABTdJREFUeNrsnD9sFEcUh5+PRMqZ
yA0SPhAUQAQFUkyTgiBASARo6QApqVIkfdxGFJFSgGhJAUIiBaQB0ZIOKVCkwUgURjIg2fxL4kS+
YDvkbC/388bi8N16Z4/d7J/5PsniuD3fyePP772ZeTsDQRAYQL/UGAJAIEAgQCBAIAAEAgQCBAIE
AkAgyJT3Mv+Eq7vYK8mTE+MDRCAghQECAeRQA5V2ZOpmg5vDx3NPzRbmGRMEcmTrEbNNB8zWfRD+
f/Efs2e3zCZvMjaksBg27TfbcuSNPEKP9ZyuAQKtHX2O9ncNgWC57umMPKvRNb0GEKgnLoUyxTQC
rcns0/6uIRAs8/hGf9cQCJZpTpjdO2f25/03z+mxntM1eLtsZAgiUtX4JcaBCAQIBAgECARQ8CJa
G5jab4J4pm4WZmO3OALVh802fIwcLkyPkcKAGggAgQCBAIEAgQCBABAIEAjKA/1AnahhbO5FdOOY
VsrrDbPBYcYKgf5D2wLaV3p+22xh1u17tO3S+DTcvxvagUDeivPgx/a/95J/73w7Sj26Hn4pKo2M
ehuV/KyBJM6d0f7k6RKx/R63vvL2tmf/ItDdM2ZTP6f7nkp9Y2fDx1v9akmpIU+KSCLVUghUQfSL
zVKeTklbLxGoctw/nzC5rw8L5KRNbkpnKq6pgSqEClzNnFzY+XnYWrt6VpVk1vbwWvg+RKCKMOUw
Q1LEOXA+/MX3mpJvGDHb265xtnzmFoUK1HaKQGlMtePYM+q2KKjXuaS1NJYIEKgI8jhEgqHt4cqy
Ky53j3hyHz2bqSLp2o2LbJ7MxKovkGqXteoWpaOk96O9/yF/dF7NwlS36AuIQIBA5celQK4PIxBE
4LLzrtoLgaALdSy6CJRkWQCBPGLsTHznomZ9nszUECgJ2ml3WWHe+QVFNPSQx6UdZNtxr9pbEShN
eTTz8mQXHoHSlke7+Z+c9m6VGoHSkEfs/trLW3wQKApN1V3lGfnGu2Z6BFoLtYCs3GWBPAiUCLVh
/HoaeRCoT9R873KLM/IgUBfapnCpe5AHgXry4pf412ihEHkQqCdxd5VqrcezhUIESsJMTJ+Pdthp
Z0WgyNlXXPHc2Mc4IVAELl2Gnh8mhUDvCkfbIVAkcbf/aOoO3fMKhqAD3frTa4quwpn0hUDOkQhI
YYBAgECAQAAU0QlYObl+5Ug8NcprZkZxjUCxRPVA6zmtEXHCBykskrhjgHXN09PoEcgFl4M4H11j
nBAoApcj6ZoPGScEAgTKApcDoTw5sgWB+sGlz1n90IBAPdE6j1o21PfcC11jLagL1oFWRyGlKU3p
OxcSJQ7NZAjkhHp/uG2HFAYIBAgECASAQIBAgECAQAAIBOkxEARBtp9wdVfAMOfIifEBIhCQwgCB
ABAI0oV2jhxZ+nfBatuPZfgBCy0Eqqo8c01b+uu51XZvzOgDWoHNTGR+pCwpLEd5svuAZXlO2uEr
PyEQ8hRWHgRCHmqg0sjTnLalv6crJQ8C/U8stqNO0I4+VZOHFIY8COS1PGL2ybd5yUMKK7s8zYmL
dujyd3n+nESgcsvzZd4/KwIhDwIhT35QA6UyE1qyxZnfvJMHgdKS549JC1qvvJOHFIY8CFR5eV5O
XimqPAhUdHnmfx+zgxdOFXkoqIGKKs/cswnb/8Oeog8HEai48nxUhiFBIORBIOShBioskkbySCLk
IQIhDwIhj28p7FApR6b1qlEbHGpkO/rr6215vi/zH1r2x7tApSGFAQIBAgECAQIBIBAgECAQIBBA
LK8FGADCTxYrr+EVJgAAAABJRU5ErkJggg==
--001a1143d0a4bef0320565b51e53--
--001a1143d0a4beea0a0565b51e52
Content-Type: message/delivery-status

Reporting-MTA: dns; googlemail.com
Arrival-Date: Wed, 21 Feb 2018 00:57:42 -0800 (PST)
X-Original-Message-ID: <001a1143d0a4bbdd730565b51e2f@google.com>

Final-Recipient: rfc822; phornthip@nichidai.co.thNopparat
Action: failed
Status: 4.0.0
Diagnostic-Code: smtp; DNS Error: 1120135 DNS type 'mx' lookup of nichidai.co.thnopparat responded with code NXDOMAIN
 Domain name not found: nichidai.co.thnopparat
Last-Attempt-Date: Wed, 21 Feb 2018 00:57:42 -0800 (PST)

--001a1143d0a4beea0a0565b51e52
Content-Type: message/rfc822

DKIM-Signature: v=1; a=rsa-sha256; c=relaxed/relaxed;
        d=gmail.com; s=20161025;
        h=mime-version:reply-to:message-id:date:subject:from:to;
        bh=nZeg6lzHKwlrO0HUNtctTfP2x6v/kw/sBvy/Q1SiHdE=;
        b=JgrYpHvocUYe4hqIYjkG9bMAsRw3JWCXtCgRCrKC12PXXvcNZxETh078UtElwLDr2C
         4+pxrRtYD50ttJMnJE27qgNOUOwWj2ndRNQOQZlloXUFZXgYjU5kGZBYXOjpEXv/RglN
         GxySqSdnhO1bfR64Pl3uXr3TrX2s3nU8zgKi3z5s7/6ruCpSWdVb16KmwYuvM7MxMdYy
         S8s0rWuf9E2NcjyLTArJKYb/el0M88VYwPwLcKb3PUSwlOYLSFi5DPu8uw6SKO0W4Ybz
         r1cQEh8RAkHU63Vlye66+LmIEEPggxJ3RRjNY7UgSq0njvq0/RkcNmdA57LQvpRjzXdJ
         Ha2g==
X-Google-DKIM-Signature: v=1; a=rsa-sha256; c=relaxed/relaxed;
        d=1e100.net; s=20161025;
        h=x-gm-message-state:mime-version:reply-to:message-id:date:subject
         :from:to;
        bh=nZeg6lzHKwlrO0HUNtctTfP2x6v/kw/sBvy/Q1SiHdE=;
        b=KXDpS/L9rQiMLGdBjCo9EKAoKe9Tp2LvnBl2WSasBqmjsDNvpGs0brzSp1BhkIk71B
         XmhR9qIG4zpDG64O1+YDJ6UHQQuzwVtgffDZb0MS+flbIhQVA4QrPyWpAzA+DXTfsGAa
         CKor28xpzP3o7XGMY5xMR8cHfysiSkxU6rU6z1kPiQqsB6Cs4sjH67Ntl+myA4WfqGdt
         XRLfcswRtgNEgGOpksBhWMQR31iVDhSHMD9HVvLUwYSzTptPKpv/wvkNbJqSihsz0Ku5
         7zHmPRwWmZb2txZZck50YwvAFpJiTrVknpXM/atLcZJK+ON1YXSep1m6COm5GVlII0/g
         6myw==
X-Gm-Message-State: APf1xPAZX3P/WRRig08m8/Vt5eVo8/HlICh9jWBHa9jJWen9uzZM2nJc
	zuxnGL/1Tbowa80v5Bm6wH4BDkJ50Hu/MfGXhpe5
X-Google-Smtp-Source: AH8x2272NLvQfbUq5IdDRE1lDsKsLojfvI/7nOAh9C0M/Rr+fRox6eImbuT0lfiZmf+sB/X4VPw/odJoode2tsG5/fxB
MIME-Version: 1.0
X-Received: by 10.36.1.209 with SMTP id 200mr1393556itk.50.1519203462665; Wed,
 21 Feb 2018 00:57:42 -0800 (PST)
Reply-To: nichidaithailand@gmail.com
X-No-Auto-Attachment: 1
Message-ID: <001a1143d0a4bbdd730565b51e2f@google.com>
Date: Wed, 21 Feb 2018 08:57:42 +0000
Subject: Transport and Food
From: nichidaithailand@gmail.com
To: phornthip@nichidai.co.thNopparat
Content-Type: multipart/alternative; boundary="001a1143d0a4bbdd510565b51e2c"

--001a1143d0a4bbdd510565b51e2c
Content-Type: text/plain; charset="UTF-8"; format=flowed; delsp=yes
Content-Transfer-Encoding: base64

4LiJ4Lix4LiZ4LmA4LiK4Li04LiN4LmD4Lir4LmJ4LiE4Li44LiT4LiB4Lij4Lit4LiB4LiC4LmJ
4Lit4Lih4Li54Lil4LmD4LiZ4LmB4Lia4Lia4Lif4Lit4Lij4LmM4Lih4LiV4LmI4Lit4LmE4Lib
4LiZ4Li14LmJOg0KVHJhbnNwb3J0IGFuZCBGb29kDQoNCuC5gOC4oeC4t+C5iOC4reC4leC5ieC4
reC4h+C4geC4suC4o+C4geC4o+C4reC4geC4guC5ieC4reC4oeC4ueC4pSDguYLguJvguKPguJTg
uYTguJvguJfguLXguYg6DQpodHRwczovL2RvY3MuZ29vZ2xlLmNvbS9mb3Jtcy9kL2UvMUZBSXBR
TFNjVFh5WkFFT052NmZfRTJHeHh6M1plNEZpb2tUWUFoekpMSG16blhWalJLOEJYYVEvdmlld2Zv
cm0/Yz0wJmFtcDt3PTEmYW1wO3VzcD1tYWlsX2Zvcm1fbGluaw0KDQrguInguLHguJnguYDguIrg
uLTguI3guYPguKvguYnguITguLjguJPguIHguKPguK3guIHguILguYnguK3guKHguLnguKXguYPg
uJnguYHguJrguJrguJ/guK3guKPguYzguKE6IOC4l+C4lOC4peC4reC4geC4geC4suC4o+C5g+C4
iuC5ieC4h+C4suC4meC4geC4o+C4uOC4k+C4suC4leC4reC4muC4geC4peC4seC4muC4oOC4suC4
ouC5g+C4meC4p+C4seC4meC4meC4teC5ieC4hOC5iOC4sA0KDQpHb29nbGUg4Lif4Lit4Lij4LmM
4LihOiDguKrguKPguYnguLLguIfguYHguKXguLDguKfguLTguYDguITguKPguLLguLDguKvguYzg
uYHguJrguJrguKrguLPguKPguKfguIgNCg==
--001a1143d0a4bbdd510565b51e2c
Content-Type: text/html; charset="UTF-8"
Content-Transfer-Encoding: quoted-printable

<html><body style=3D"font-family: Roboto,Helvetica,Arial,sans-serif; margin=
: 0; padding: 0; height: 100%; width: 100%;"><table border=3D"0" cellpaddin=
g=3D"0" cellspacing=3D"0" style=3D"background-color:rgb(61, 143, 45);" widt=
h=3D"100%" role=3D"presentation"><tbody><tr height=3D"64px"><td style=3D"pa=
dding-left: 24px"><img alt=3D"Google =E0=B8=9F=E0=B8=AD=E0=B8=A3=E0=B9=8C=
=E0=B8=A1" height=3D"26px" style=3D"display: inline-block; margin: 0; verti=
cal-align: middle;" width=3D"143px" src=3D"https://www.gstatic.com/docs/for=
ms/google_forms_logo_lockup_white_2x.png"></td></tr></tbody></table><div st=
yle=3D"padding: 24px; background-color:rgb(205, 231, 199)"><table align=3D"=
center" border=3D"0" cellpadding=3D"0" cellspacing=3D"0" style=3D"max-width=
: 672px; min-width: 154px;" width=3D"100%" role=3D"presentation"><tbody><tr=
><td style=3D"font-size: 13px; line-height: 18px; color: #424242; font-weig=
ht: 700">=E0=B8=AB=E0=B8=B2=E0=B8=81=E0=B8=9E=E0=B8=9A=E0=B8=9B=E0=B8=B1=E0=
=B8=8D=E0=B8=AB=E0=B8=B2=E0=B9=83=E0=B8=99=E0=B8=81=E0=B8=B2=E0=B8=A3=E0=B8=
=94=E0=B8=B9=E0=B8=AB=E0=B8=A3=E0=B8=B7=E0=B8=AD=E0=B8=AA=E0=B9=88=E0=B8=87=
=E0=B9=81=E0=B8=9A=E0=B8=9A=E0=B8=9F=E0=B8=AD=E0=B8=A3=E0=B9=8C=E0=B8=A1=E0=
=B8=99=E0=B8=B5=E0=B9=89</td></tr><tr height=3D"8px"><td></td></tr><tr><td>=
<table border=3D"0" cellpadding=3D"0" cellspacing=3D"0" width=3D"100%"><tbo=
dy><tr><td><a href=3D"https://docs.google.com/forms/d/e/1FAIpQLScTXyZAEONv6=
f_E2Gxxz3Ze4FiokTYAhzJLHmznXVjRK8BXaQ/viewform?c=3D0&amp;w=3D1&amp;usp=3Dma=
il_form_link" style=3D"border-radius: 3px; box-sizing: border-box; display:=
 inline-block; font-size: 13px; font-weight: 700; height: 40px; line-height=
: 40px; padding: 0 24px; text-align: center; text-decoration: none; text-tr=
ansform: uppercase; vertical-align: middle; color: #fff; background-color: =
rgb(61, 143, 45);" target=3D"_blank" rel=3D"noopener">=E0=B8=81=E0=B8=A3=E0=
=B8=AD=E0=B8=81=E0=B8=82=E0=B9=89=E0=B8=AD=E0=B8=A1=E0=B8=B9=E0=B8=A5=E0=B9=
=83=E0=B8=99 Google =E0=B8=9F=E0=B8=AD=E0=B8=A3=E0=B9=8C=E0=B8=A1</a></td><=
/tr></tbody></table></td></tr><tr height=3D"24px"><td></td></tr></tbody></t=
able><div align=3D"center" style=3D"background-color: #fff; border-bottom: =
1px solid #e0e0e0; margin: 0 auto; max-width: 624px; min-width: 154px; padd=
ing: 0 24px;"><table align=3D"center" cellpadding=3D"0" cellspacing=3D"0" s=
tyle=3D"background-color: #fff;" width=3D"100%" role=3D"presentation"><tbod=
y><tr height=3D"24px"><td></td></tr><tr><td><span style=3D"display: table-c=
ell; vertical-align: top; font-size: 13px; line-height: 18px; color: #42424=
2;">=E0=B8=89=E0=B8=B1=E0=B8=99=E0=B9=80=E0=B8=8A=E0=B8=B4=E0=B8=8D=E0=B9=
=83=E0=B8=AB=E0=B9=89=E0=B8=84=E0=B8=B8=E0=B8=93=E0=B8=81=E0=B8=A3=E0=B8=AD=
=E0=B8=81=E0=B8=82=E0=B9=89=E0=B8=AD=E0=B8=A1=E0=B8=B9=E0=B
----- Message truncated -----

--001a1143d0a4beea0a0565b51e52--
