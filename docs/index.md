---
layout: default
title: "TG - Game Development Blog"
description: "Welcome my dear reader!"
---


# Welcome to My GMD Project Blog 🚀
<!-- This is a simple Jekyll-powered blog hosted on **GitHub Pages**. -->

## 📌 Recent Posts
{% for post in site.posts %}
- [{{ post.title }}]({{ post.url }}) - *{{ post.date | date: "%B %d, %Y" }}*
  {% endfor %}

---

## 📖 About This Site
I'm documenting my journey in **GMD game project**, sharing insights about the process.

<!--
🌟 **Want to explore?** Check out:
- [Latest Articles](/blog)
- [About Me](/about)
- [Contact](/contact)
-->
Enjoy the content, and feel free to reach out! 😊
