---
title: "TG :: Game developement blog."
description: "Welcome my dear reader!"
layout: default
---

---
layout: default
---

<h1>Blog Posts</h1>
<ul>
  {% for post in site.posts %}
    <li>
      <a href="{{ post.url }}">{{ post.title }}</a>
    </li>
  {% endfor %}
</ul>

<link rel="stylesheet" type="text/css" href="assets/css/style.css">