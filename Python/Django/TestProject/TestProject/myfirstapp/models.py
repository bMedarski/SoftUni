from django.db import models

# Create your models here.

class Author(models.Model):
    name = models.CharField(max_length=50, unique=True, null=False)

class Book(models.Model):
    title = models.CharField(max_length=50),
    author = models.ForeignKey(
		Author,
		on_delete=models.SET_NULL,
		null=True
	),

    created_at = models.DateTimeField(auto_now_add=True)