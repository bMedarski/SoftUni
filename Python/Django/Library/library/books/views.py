from django.shortcuts import render
from django.http import HttpResponse
from django.views import generic
from .models import Author


# Create your views here.
# def index(request):
#     context = {'data':request}
#     return render(request,'books/home.html',context)
#
# def detail(request,id):
#     return HttpResponse(f"<p>This is book №{id}</p>")

class IndexView(generic.ListView):
    template_name = 'books/home.html'
    context_object_name = 'authors'
    def get_queryset(self):
        return Author.objects.all()

class DetailView(generic.DetailView):
    model = Author
    template_name = 'books/detail.html'