from django.shortcuts import render
from django.http import HttpResponse
from django.views import generic
from .models import Author


class IndexView(generic.ListView):
    template_name = 'books/home.html'
    context_object_name = 'authors'
    def get_queryset(self):
        return Author.objects.all()

class DetailView(generic.DetailView):
    model = Author
    template_name = 'books/author-detail.html'