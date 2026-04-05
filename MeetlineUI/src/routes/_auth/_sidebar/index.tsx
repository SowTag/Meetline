import { createFileRoute } from '@tanstack/react-router'
import { Input } from '#/components/ui/input.tsx'
import { Search } from 'lucide-react'
import {
  ResizableHandle,
  ResizablePanel,
  ResizablePanelGroup,
} from '#/components/ui/resizable.tsx'

export const Route = createFileRoute('/_auth/_sidebar/')({
  component: Index,
})

function Index() {
  return <span>index</span>
}
